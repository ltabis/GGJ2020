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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (status == ReperableStatus.Using)
        {
            activated = true;
        }
    }

    private void Explode()
    {
        Destroy(this);
    }
}
