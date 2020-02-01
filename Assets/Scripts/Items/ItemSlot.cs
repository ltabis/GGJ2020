using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public GameObject itemData;

    // UI.
    private Item _item;
    public Button buttonUI;
    public Button crossUI;
    public Image slotUI;
    public Text quantityUI;

    // Other.
    private uint _quantity = 0;

    private void Start()
    {
        // Setting a callback when the button is clicked.
        crossUI.onClick.AddListener(RemoveItem);

        // The slot is empty, toggle off everything.
        ToggleGUI(false);
    }

    private void Update()
    {
        if (itemData.activeSelf)
            itemData.transform.position = Input.mousePosition;
    }

    // Display data sheet of the item.
    public void DisplayData()
    {
        itemData.SetActive(true);
    }
    public void HideData()
    {
        itemData.SetActive(false);
    }

    // Toggle the UI on and off.
    private void ToggleGUI(bool toggle)
    {
        crossUI.gameObject.SetActive(toggle);
        buttonUI.gameObject.SetActive(toggle);
        quantityUI.gameObject.SetActive(toggle);
    }

    // Add an item to the slot and the virtual inventory.
    public void AddItem(Item item, uint quantity)
    {
        buttonUI.image.sprite = item.artwork;
        quantityUI.text = (_quantity + quantity).ToString();
        _item = item;
        _quantity += quantity;
        itemData.GetComponent<ItemDisplay>().item = item;
        ToggleGUI(true);
    }

    // Remove an item from the slot and the inventory.
    public void RemoveItem()
    {
        ToggleGUI(false);
        _quantity = 0;
    }
}
