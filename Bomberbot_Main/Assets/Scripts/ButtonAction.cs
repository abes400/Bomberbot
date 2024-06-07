using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public Sprite idle, hover;
    public Button thisButton;

    private void Start()
    {
        thisButton = gameObject.GetComponent<Button>();
        thisButton.image.sprite = idle;
    }

    public void onHoverEnter()
    {
        thisButton.image.sprite = hover;
    }

    public void onHoverExit()
    {
        thisButton.image.sprite = idle;

    }
}
