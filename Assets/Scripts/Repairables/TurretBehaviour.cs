using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : ARepairable
{
    private float reload = 1;

    public ATurret turret;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (status == ReperableStatus.Repair)
        {
            GameObject target = FindNearestEnnemy();
            if (target != null)
            {
                reload -= Time.deltaTime;
                RotateEntityWithEnemy(target);
                if (reload <= 0)
                {
                    Shoot(target);
                    reload = turret.cooldown;
                }
            }
        }
    }

    // Spwan munition gameObject
    private void Shoot(GameObject target)
    {
        Debug.Log("shooooot");
        GameObject spawn = Instantiate(turret.bullet, gameObject.transform.position, gameObject.transform.rotation);
        spawn.transform.SetParent(gameObject.transform);
        spawn.GetComponent<BulletBehaviour>().direction = target.transform.position - gameObject.transform.position;
    }

    // Rotate the object, following the mouse cursor.
    private void RotateEntityWithEnemy(GameObject enemy)
    {
        var dir = enemy.transform.position - gameObject.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Find the nearer enemy. If there is not, return null
    private GameObject FindNearestEnnemy()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearer = null;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (nearer == null)
                nearer = enemies[i];
            else if (Vector3.Distance(enemies[i].transform.position, gameObject.transform.position) < Vector3.Distance(nearer.transform.position, gameObject.transform.position))
                nearer = enemies[i];
        }
        return nearer;
    }
}
