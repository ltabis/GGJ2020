using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInventory : MonoBehaviour
{
    // Public.
    public List<Item> prefabList;

    // Private.
    protected string _name;
    protected uint _fixedSize;
    protected List<Item> _content;

    // Take an item from the current inventory
    public Item Take(string toFind)
    {

        // Searching for the item.
        foreach (var item in _content)
        {
            // Found the item, getting it.
            if (item.name == toFind)
                return item;

            _content.Remove(item);
        }

        // Item hasn't been found.
        return null;
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
