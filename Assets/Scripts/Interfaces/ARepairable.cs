using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReperableStatus
{
    Broken, Repairing, Using, Unused, Unusable
};

public class ARepairable : MonoBehaviour
{
    public float repairTime;
    public float energyCost;
    public ReperableStatus status = ReperableStatus.Broken;

    public float Repair(float value, float energy)
    {
        if (status == ReperableStatus.Unusable)
            return 0;
        // Starting to repair
        if (status == ReperableStatus.Broken)
        {
            status = ReperableStatus.Repairing;
        }
        // Repaired, but needs energy to function.
        else if (status == ReperableStatus.Unused && energy >= energyCost)
        {
            status = ReperableStatus.Using;
            return -energyCost;
        }
        // Using, desactivating the device.
        else if (status == ReperableStatus.Using)
        {
            status = ReperableStatus.Unused;
            return energyCost;
        }
        repairTime -= value;
        if (repairTime <= 0)
            status = ReperableStatus.Unused;
        return 0;
    }

    public ReperableStatus Status()
    {
        return status;
    }
}