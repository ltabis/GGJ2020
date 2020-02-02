using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : ARepairable
{
    public bool activated = false;
    public ATrap trap;

    private List<GameObject> InRadius = new List<GameObject>();

    public AudioSource audio;

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            Activation();
            activated = false;
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
        audio.Play();
        for (int i = 0; i < InRadius.Count; i++)
        {
            bool isPlayer = false;
            if (InRadius[i] && InRadius[i].tag == "Player")
                isPlayer = true;
            InRadius[i].GetComponent<AEntity>().TakeDamage(trap.damage);
            if (isPlayer)
                GameObject.FindObjectOfType<HUD>().OnUpdate();
        }
        status = ReperableStatus.Broken;
        InRadius.Clear();
    }
}
