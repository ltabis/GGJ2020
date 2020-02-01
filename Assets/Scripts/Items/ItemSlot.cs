using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // Inventory.
    public Inventory inventory;

    // UI.
    public Button buttonUI;
    public Image slotUI;
    public Image crossUI;
    public Text quantityUI;

    // Other.
    private uint _quantity = 0;

    private void Start()
    {
        // Setting a callback for the player.
        buttonUI.onClick.AddListener(TransferItem);

        // The slot is empty, toggle off everything.
        ToggleGUI(false);
    }
    private void TransferItem()
    {

    }

    // Toggle the UI on and off.
    private void ToggleGUI(bool toggle)
    {
        buttonUI.gameObject.SetActive(toggle);
        crossUI.gameObject.SetActive(toggle);
        quantityUI.gameObject.SetActive(toggle);
    }

    // Add an item to the slot and the virtual inventory.
    public void AddItem(Item item, uint quantity)
    {
        inventory.Add(item, _quantity + quantity);

        buttonUI.image.sprite = item.artwork;
        quantityUI.text = (_quantity + quantity).ToString();
        ToggleGUI(true);
    }

    // Remove an item from the slot and the inventory.
    public void removeItem(Item item)
    {
        inventory.Remove(item.name);

        ToggleGUI(false);
        _quantity = 0;
    }
}
