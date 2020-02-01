using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherItemSlot : MonoBehaviour
{
    // UI.
    public Button buttonUI;
    public Image slotUI;
    public Text quantityUI;

    private bool set = false;

    private void Start()
    {
        // The slot is empty, toggle off everything.
        if (!set)
            ToggleGUI(false);
    }

    // Toggle the UI on and off.
    private void ToggleGUI(bool toggle)
    {
        buttonUI.gameObject.SetActive(toggle);
        quantityUI.gameObject.SetActive(toggle);
        slotUI.gameObject.SetActive(toggle);
    }

    public void AddItem(Item item, uint quantity)
    {
        // Copying item data.
        buttonUI.image.sprite = item.artwork;
        quantityUI.text = quantity.ToString();

        // Displaying Inventory
        set = true;
        ToggleGUI(true);
    }

    // Remove an item from the slot and the inventory.
    public void RemoveItem()
    {
        ToggleGUI(false);
    }
}
