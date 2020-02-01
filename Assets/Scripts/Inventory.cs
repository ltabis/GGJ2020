using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // UI.
    public Canvas canvas;

    // Public.
    public List<Item> prefabList;

    // Private.
    protected string _name = "Inventory";
    protected uint _fixedSize = 0;
    protected List<Item> _content;

    private void Start()
    {
        Generate();
    }

    // Set the inventory visible or not.
    public void ToggleInventory(bool toggle)
    {
        canvas.gameObject.SetActive(toggle);
    }

    // Take an item from the current inventory
    public Item Take(string toFind)
    {

        // Searching for the item.
        foreach (var item in _content)
        {
            // Found the item, getting it.
            if (item.name == toFind)
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
            if (item.name == toFind)
                _content.Remove(item);
        }
    }

    // Adds an item to the inventory.
    public void Add(Item item)
    {
        _content.Add(item);
    }

    // Generates a random set of items.
    public void Generate()
    {
        uint itemsToGenerate = (uint)Random.Range(0, _fixedSize);

        // Generate as much items as the random suggest.
        for (uint item = 0; item < itemsToGenerate; ++item)
        {
            // Generates a random item. (Needs to add item tier list rate)
            int prefabIndex = Random.Range(0, prefabList.Count);

            _content.Add(prefabList[prefabIndex]);
        }
    }
}
