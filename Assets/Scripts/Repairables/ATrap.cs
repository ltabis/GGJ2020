using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Trap", menuName = "ScriptableObjects/Trap", order = 2)]
public class ATrap : ScriptableObject
{
    public string trapName;
    public bool isPlayerSensible;
    public float damage = 5;
    public float cooldown = 5;

    public Sprite destroySprite;
    public Sprite inRepaireSprite;
    public Sprite repaireSprite;
}
