using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OtherInventory : Inventory
{
    // Inventory slots.
    public GameObject itemsParent;
    private OtherItemSlot[] _otherItemSlotsUI;

    // Public.
    public List<Item> prefabList;

    private void Start()
    {
        // Getting all slots.
        _otherItemSlotsUI = itemsParent.GetComponentsInChildren<OtherItemSlot>();

        _fixedSize = 5;

        // Generating items.
        Generate();
    }

    // Generates a random set of items.
    public void Generate()
    {
        uint itemsToGenerate = (uint)UnityEngine.Random.Range(0, _fixedSize);

        // Generate as much items as the random suggest.
        for (uint item = 0; item < itemsToGenerate; ++item)
        {
            // Generates a random item. (Needs to add item tier list rate)
            int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count);

            // Adding the item to the virtual inventory.
            _content.Add(new Tuple<Item, uint>(prefabList[prefabIndex], 1));

            // Adding the item to the UI.
            _otherItemSlotsUI[item].AddItem(prefabList[prefabIndex], 1);
        }
    }

    // Change ownership of the items.
    public List<Tuple<Item, uint>> GetAllItems()
    {
        var items = _content;

        _content.Clear();
        return items;
    }
}
