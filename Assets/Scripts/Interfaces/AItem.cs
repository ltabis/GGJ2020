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

    protected string _name;
    protected string _description;
    protected Rarity _rarity;
    protected float _price;
}