using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReperableStatus
{
    Broken, Repairing, Using, Unused
};

public class ARepairable : MonoBehaviour
{
    public float repairTime;
    public ReperableStatus status = ReperableStatus.Broken;

    public void Repair(float value)
    {
        if (status == ReperableStatus.Broken)
        {
            status = ReperableStatus.Repairing;
        }
        repairTime -= value;
        if (repairTime <= 0)
            status = ReperableStatus.Unused;
    }

    public bool Use()
    {
        if (repairTime > 0)
            return false;

        if (status == ReperableStatus.Using)
            status = ReperableStatus.Unused;
        else
            status = ReperableStatus.Using;
        return true;
    }
}