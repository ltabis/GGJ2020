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

    // Parent of slots
    public GameObject itemsParent;

    public uint scrap = 50;

    // Object detection.
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        _life = 100;
        _maxLife = 100;
        _shield = 100;
        _maxShield = 100;
        _energy = 100;
        _maxEnergy = 100;
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
    private Collider ObjectOver()
    {
        // Get the current mouse position.
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
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
            if (Input.GetButtonDown("Use") == true && scrap > 0)
            {
                var repairable = collider.GetComponentInChildren<ARepairable>();

                repairable.Repair(1);
                scrap -= 1;
                hud.OnUpdate();
            }

        }
        else if (otherInventory != null)
            otherInventory.ToggleInventory(false);
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
