﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Trap", menuName = "ScriptableObjects/Trap", order = 2)]
public class ATrap : ScriptableObject
{
    public string trapName;
    public bool isPlayerSensible;
    public float damage = 5;
    public float cooldown = 5;
    public float activationTime = 0;

    public Sprite Repairing;
    public Sprite Unused;
}
