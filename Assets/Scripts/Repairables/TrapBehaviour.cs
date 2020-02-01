using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : ARepairable
{
    public bool activated = false;
    public ATrap trap;

    private List<GameObject> InRadius = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (trap.cooldown <= 0)
            {
                Activation();
                activated = false;
            }
            else
                trap.cooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "player")
        {
            InRadius.Add(other.gameObject);
        }
        if (status == ReperableStatus.Using)
        {
            activated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "player")
        {
            InRadius.Remove(other.gameObject);
        }
    }

    private void Activation()
    {
        for (int i = 0; i < InRadius.Count; i++)
        {
            InRadius[i].GetComponent<AEntity>().TakeDamage(trap.damage);
        }
        InRadius.Clear();
    }
}
