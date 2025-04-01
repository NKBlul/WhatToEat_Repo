using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public void LoadEatLevel()
    {
        SceneManager.LoadScene("WhatToEatScene");
    }

    public void LoadPlayLevel()
    {
        SceneManager.LoadScene("");
    }

    public void LoadWatchLevel()
    {
        SceneManager.LoadScene("");
    }
}
