using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // UI.
    public Canvas canvas;

    // Private.
    protected string _name = "Inventory";
    protected uint _fixedSize = 0;
    protected List<Tuple<Item, uint>> _content = new List<Tuple<Item, uint>>();

    // Set the inventory visible or not.
    public void ToggleInventory(bool toggle)
    {
        canvas.gameObject.SetActive(toggle);
    }

    // Take an item from the current inventory
    public Tuple<Item, uint> Take(string toFind)
    {

        // Searching for the item.
        foreach (var item in _content)
        {
            // Found the item, getting it.
            if (item.Item1.name == toFind)
            {
                // Removing the item from the inventory list.
                var itemCpy = item;
                _content.Remove(item);
                return itemCpy;
            }
        }

        // Item hasn't been found.
        return null;
    }

    // Removes item from the current inventory
    public void Remove(string toFind)
    {

        // Searching for the item.
        foreach (var item in _content)
        {
            // Found the item, getting it.
            if (item.Item1.name == toFind)
                _content.Remove(item);
        }
    }

    // Adds an item to the inventory.
    public void Add(Item newItem, uint quantity)
    {
        int idx = 0;

        foreach (var item in _content)
        {

            // Search if the inventory already contains the item.
            if (item.Item1.name == newItem.name)
            {

                // Add quantity.
                _content[idx] = new Tuple<Item, uint>(item.Item1, item.Item2 + quantity);
                return;
            }
            ++idx;
        }

        // Add a new item to the inventory?
        if (_content.Count < _fixedSize)
            _content.Add(new Tuple<Item, uint>(newItem, quantity));
        else
            Debug.Log("Inventory is full.");
    }
}
