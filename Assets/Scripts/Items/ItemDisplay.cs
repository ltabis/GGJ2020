using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    public Item item;

    public Image artwork;

    public Text nameText;
    public Text descriptionText;
    public Text priceText;
    public Text rarityText;

    // Start is called before the first frame update
    void Start()
    {
        artwork.sprite = item.artwork;

        nameText.text = item.name;
        descriptionText.text = item.description;
        priceText.text = item.price.ToString();
        rarityText.text = item.rarity.ToString();
    }
}
