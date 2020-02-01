using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : ARepairable
{
    public float cooldown = 5;
    private float reload = 5;

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
            GameObject target = FindNearerEnnemy();
            if (target != null)
            {
                reload -= Time.deltaTime;
                RotateEntityWithEnemy(target);
                if (reload <= 0)
                {
//                    Shoot(target);
                    reload = cooldown;
                }
            }
        }
    }

    // Spwan munition gameObject
    private void Shoot(GameObject target)
    {
        GameObject spawn = Instantiate(munition, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
        spawn.transform.SetParent(gameObject.transform);
    }

    // Rotate the object, following the mouse cursor.
    private void RotateEntityWithEnemy(GameObject enemy)
    {
        var dir = enemy.transform.position - gameObject.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Find the nearer enemy. If there is not, return null
    private GameObject FindNearerEnnemy()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearer = null;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (nearer == null)
                nearer = enemies[i];
            else if (Vector3.Distance(enemies[i].transform.position, gameObject.transform.position) > Vector3.Distance(nearer.transform.position, gameObject.transform.position))
            {
                nearer = enemies[i];
            }
        }
        return nearer;
    }
}
