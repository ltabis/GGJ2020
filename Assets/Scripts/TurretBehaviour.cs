using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : ARepairable
{
    public Sprite destroySprite;
    public Sprite inRepaireSprite;
    public Sprite repaireSprite;

    public GameObject munition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (status == ReperableStatus.Repair)
        {
            RotateEntityWithPlayer();
            Shoot();
        }
    }

    // Rotate the object, following the mouse cursor.
    private void RotateEntityWithPlayer()
    {
        // Getting distance between mouse and object.
        var dir = GameObject.FindGameObjectWithTag("Player").transform.position - gameObject.transform.position;

        // Weird maths 0_0
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        // Applying rotation to the object.
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Shoot()
    {
        GameObject spawn = Instantiate(munition, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
        spawn.transform.SetParent(gameObject.transform);
        spawn.GetComponent<BulletBehaviour>().direction = FindNearerEnnemy();
    }

    private GameObject FindNearerEnnemy()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearer = null;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (nearer == null)
                nearer = enemies[i];
//            else if ()
        }
    }
}
