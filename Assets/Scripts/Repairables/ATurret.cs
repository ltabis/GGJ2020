using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Turret", menuName = "ScriptableObjects/Turret", order = 1)]
public class ATurret : ScriptableObject
{
    public string turretName;
    public float damage = 5;
    public float cooldown = 5;

    public Sprite destroySprite;
    public Sprite inRepaireSprite;
    public Sprite repaireSprite;

    public GameObject bullet;
}
