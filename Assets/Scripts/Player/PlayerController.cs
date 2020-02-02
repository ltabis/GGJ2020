using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AEntity
{
    // HUD.
    public HUD hud;

    // Inventory.
    public Inventory inventory;
    private OtherInventory otherInventory = null;
    private bool _isInventoryOpen = false;
    private bool dead = false;

    // Parent of slots
    public GameObject itemsParent;

    public uint scrap = 50;

    private void Start()
    {
        _life = 100;
        _maxLife = 100;
        _shield = 100;
        _maxShield = 100;
        _energy = 100;
        _maxEnergy = 200;
        _damage = 0;
        _range = 5;
        _speed = 5;

        hud = GameObject.Find("HUD").GetComponent<HUD>();
        hud.OnUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isInventoryOpen)
        {
            RotateEntityWithMouse();
            Movements();
        }
        Interactions();
        PlayerInput();
    }

    private void OnDestroy()
    {
        GameObject.Find("HUD").GetComponent<HUD>().PrintDeath();
    }

    // Handles movements from the player.
    private void Movements()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * Speed() * Time.deltaTime, Input.GetAxis("Vertical") * Speed() * Time.deltaTime, 0);
    }

    // Rotate the object, following the mouse cursor.
    private void RotateEntityWithMouse()
    {
        // Transform position into screen position.
        var pos = Camera.main.WorldToScreenPoint(transform.position);

        // Getting distance between mouse and object.
        var dir = Input.mousePosition - pos;

        // Weird maths 0_0
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        // Applying rotation to the object.
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Mouse over objects.
    private Collider2D ObjectOver()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit)
        {
            return hit.collider;
        }

        return null;
    }

    private void Interactions()
    {
        // Getting an eventual object.
        var collider = ObjectOver();

        if (collider && collider.CompareTag("Treasure"))
        {
            var tmpInventory = collider.GetComponentInChildren<OtherInventory>();

            if (Input.GetButtonDown("Use") == true)
            {
                var items = otherInventory.GetAllItems();
                foreach (var item in items)
                {
                    inventory.Add(item.Item1, item.Item2);
                }
            }

            if (tmpInventory != null)
            {
                if (otherInventory != null)
                    otherInventory.ToggleInventory(false);
                otherInventory = tmpInventory;
                otherInventory.ToggleInventory(true);
            }
        }
        else if (collider && collider.CompareTag("Repairable"))
        {
            if (Input.GetButtonDown("Use") == true)
            {
                var repairable = collider.GetComponentInChildren<ARepairable>();

                // Check if the player can repair the object.
                if ((repairable.Status() == ReperableStatus.Broken || repairable.Status() == ReperableStatus.Repairing) && scrap > 0)
                {
                    repairable.Repair(1, _energy);
                    scrap -= 1;
                }
                else
                {
                    // Remove or add energy.
                    _energy += repairable.Repair(1, _energy);
                }
            }

        }
        else if (otherInventory != null)
            otherInventory.ToggleInventory(false);
        // update the hud.
        hud.OnUpdate();
    }

    private void DisplayInventory()
    {
        // Changing the state of the inventory.
        _isInventoryOpen = !_isInventoryOpen;
        inventory.ToggleInventory(_isInventoryOpen);
    }

    private void PlayerInput()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            DisplayInventory();
        }
    }
}
