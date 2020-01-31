using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AReperable : MonoBehaviour
{
    public enum ReperableStatus
    {
        Broken, Repair, Use
    };

    public float repairTime;
    public ReperableStatus status = ReperableStatus.Broken;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Repair(float value)
    {
        if (status == ReperableStatus.Broken)
            status = ReperableStatus.Use;
        repairTime -= value;
        if (repairTime <= 0)
            status = ReperableStatus.Repair;
    }
}
