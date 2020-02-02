using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostBehaviour : ARepairable
{
    public bool activated = false;
    public float energy = 50;
    public ATrap trap;
    public AudioSource sound;

    public GameObject StatusUI;

    private ReperableStatus currentStatus = ReperableStatus.Broken;

    // UI.
    RectTransform canvas;
    RectTransform image;
    private Vector2 uiOffset;

    private void Start()
    {
        canvas = StatusUI.GetComponent<RectTransform>();

        // Not great.
        image = transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>();

        // Computing offset.
        uiOffset = new Vector2(canvas.sizeDelta.x / 2f, canvas.sizeDelta.y / 2f);
        StatusUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayStatus();
        if (status == ReperableStatus.Using)
        {
            var controller = GameObject.Find("Body").GetComponent<PlayerController>();

            if (controller)
            {
                sound.Play();
                controller.AddEnergy(50);
                status = ReperableStatus.Unusable;
            }
        }
    }

    private void DisplayStatus()
    {
        if (status == ReperableStatus.Repairing && currentStatus != ReperableStatus.Repairing)
        {
            StatusUI.GetComponentInChildren<Image>().sprite = trap.Repairing;
            StatusUI.SetActive(true);

            currentStatus = ReperableStatus.Repairing;
        }
        else if (status == ReperableStatus.Unused && currentStatus != ReperableStatus.Unused)
        {
            StatusUI.GetComponentInChildren<Image>().sprite = trap.Unused;
            StatusUI.SetActive(true);

            currentStatus = ReperableStatus.Unused;
        }
        else if (status != ReperableStatus.Unused && status != ReperableStatus.Repairing)
            StatusUI.SetActive(false);

        // Changing the position of the sprite.
        SetUIPosition();
    }

    private void SetUIPosition()
    {
        // Get the position on the canvas
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 proportionalPosition = new Vector2(ViewportPosition.x * canvas.sizeDelta.x, ViewportPosition.y * canvas.sizeDelta.y);

        // Set the position and remove the screen offset
        image.localPosition = proportionalPosition - uiOffset;
    }
}