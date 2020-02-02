using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostBehaviour : ARepairable
{
    public bool activated = false;
    public float energy = 50;
    public ATrap trap;

    // Update is called once per frame
    void Update()
    {
        if (status == ReperableStatus.Using)
        {
            var controller = GameObject.Find("Body").GetComponent<PlayerController>();

            if (controller)
            {
                controller.AddEnergy(50);
                status = ReperableStatus.Unusable;
            }
        }
    }
}
