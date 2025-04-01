using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WhatToEat : MonoBehaviour
{
    public static WhatToEat instance;

    [SerializeField] Image foodImage;
    [SerializeField] TextMeshProUGUI foodText;
    [SerializeField] Button button;
    [SerializeField] Button backButton;

    private void Awake()
    {
        backButton.onClick.AddListener(() => ScenesManager.instance.LoadScene("MainScreen"));
    }

    public void ChangeImageAndText(Sprite image, string name)
    {
        foodImage.sprite = image;
        foodText.text = name;
    }

    public void ButtonInteractable(bool interactable)
    {
        button.interactable = interactable;
    }
}
