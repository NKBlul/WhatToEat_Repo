using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] Image foodImage;
    [SerializeField] TextMeshProUGUI foodText;
    [SerializeField] Button button;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
