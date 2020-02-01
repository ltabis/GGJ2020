using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Interface for item usage.
public interface IItem
{
    void Use();
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
// Abstract class for Item characteristics.
public class Item : ScriptableObject
{
    // Default characteristics values.
    public string description = "None.";
    public Rarity rarity = Rarity.Useless;
    public float price = 0;
    public uint id = 0;
    public uint maxQuantity = 9999;

    // UI.
    public Sprite artwork;

    public enum Rarity
    {
        Useless,
        Common,
        Rare,
        Epic,
        Legendary
    };

    // Get rarity chance rate.
    public float GetItemRarityPercentage(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Useless :
                return 10;
            case Rarity.Common:
                return 8.50f;
            case Rarity.Rare:
                return 6.75f;
            case Rarity.Epic:
                return 3.33f;
            case Rarity.Legendary:
                return 1.25f;
        }
   
        return 0;
    }
}