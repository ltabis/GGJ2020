using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    // Bars.
    public RawImage lifeBar;
    public RawImage ShieldBar;
    public RawImage EnergyBar;

    public Text lifeText;
    public Text ShieldText;
    public Text EnergyText;
    public Text ScrapText;

    // Controller.
    public PlayerController controller;

    // Called by the controller.
    public void OnUpdate()
    {
        lifeBar.rectTransform.sizeDelta =   new Vector2((controller.Life() / controller.MaxLife()) * 200, lifeBar.rectTransform.sizeDelta.y);
        ShieldBar.rectTransform.sizeDelta = new Vector2((controller.Shield() / controller.MaxShield()) * 200, ShieldBar.rectTransform.sizeDelta.y);
        EnergyBar.rectTransform.sizeDelta = new Vector2((controller.Energy() / controller.MaxEnergy()) * 200, EnergyBar.rectTransform.sizeDelta.y);

        lifeText.text = controller.Life() + " / " + controller.MaxLife();
        ShieldText.text = controller.Shield() + " / " + controller.MaxShield();
        EnergyText.text = controller.Energy() + " / " + controller.MaxEnergy();
        ScrapText.text = controller.scrap.ToString();
    }

    public void PrintDeath()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
