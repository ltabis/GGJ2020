using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for item usage.
public interface IItem
{
    void Use();
}

// Abstract class for Item characteristics.
abstract public class AItem : MonoBehaviour
{
    public enum Rarity
    {
        Useless, Common, Rare, Epic, Legendary
    };

    protected string _name = "Unknown";
    protected string _description = "None.";
    protected Rarity _rarity = Rarity.Useless;
    protected float _price = 0;
}