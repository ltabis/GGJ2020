using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantNoodlesItem : AItem, IItem
{
    // Start is called before the first frame update
    void Start()
    {
        _description = "A basic set of noodles. Cheap. But strong has hell.";
        _name = "Instant noodles";
        _price = 100;
        _rarity = Rarity.Epic;
    }

    public void Use()
    {
        Debug.Log("The noodles are beeing used!");
    }
}
