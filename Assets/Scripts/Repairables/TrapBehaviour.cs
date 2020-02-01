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
            Activation();
        }
        if (trap.cooldown > 0)
        {
            trap.cooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
            InRadius.Add(other.gameObject);
            if (status == ReperableStatus.Using && trap.cooldown <= 0)
            {
                activated = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
            InRadius.Remove(other.gameObject);
        }
    }

    private void Activation()
    {
        for (int i = 0; i < InRadius.Count; i++)
        {
            Debug.Log("Damaged : " + InRadius[i].name);
            InRadius[i].GetComponent<AEntity>().TakeDamage(trap.damage);
        }
        status = ReperableStatus.Broken;
        activated = false;
        InRadius.Clear();
    }
}
