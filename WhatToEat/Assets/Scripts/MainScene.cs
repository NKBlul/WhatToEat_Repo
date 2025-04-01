using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    [SerializeField] Button eatButton;
    [SerializeField] Button playButton;
    [SerializeField] Button watchButton;

    private void Awake()
    {
        eatButton.onClick.AddListener(() => ScenesManager.instance.LoadScene("WhatToEatScene"));
        playButton.onClick.AddListener(() => ScenesManager.instance.LoadScene("WhatToPlayScene"));
        watchButton.onClick.AddListener(() => ScenesManager.instance.LoadScene("WhatToWatchScene"));
    }
}
