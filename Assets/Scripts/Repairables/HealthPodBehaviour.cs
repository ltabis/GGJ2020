using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPodBehaviour : ARepairable
{
    public ATrap trap;

    public AudioSource sound;

    void Update()
    {
        if (status == ReperableStatus.Using)
        {
            var controller = GameObject.Find("Body").GetComponent<PlayerController>();

            if (controller)
            {
                sound.Play();
                controller.AddLife(20);
                status = ReperableStatus.Unusable;
            }
        }
    }
}
