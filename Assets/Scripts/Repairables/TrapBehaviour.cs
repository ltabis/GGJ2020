using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : ARepairable
{
    public bool activated = false;
    public ATrap trap;

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (trap.cooldown <= 0)
                Explode();
            else
                trap.cooldown -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (status == ReperableStatus.Repair)
        {
            Debug.Log(collision.gameObject.name);
            activated = true;
        }

    }

    private void Explode()
    {
        Destroy(this);
    }
}
