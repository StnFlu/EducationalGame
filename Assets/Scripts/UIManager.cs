using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    public Canvas menu;

    public void PauseGame()
    {
        menu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        menu.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void AdjustEffects()
    {

    }

    void AdjustMusic()
    {

    }

    public void Fullscreen()
    {
        if (!Screen.fullScreen)
            Screen.fullScreen = true;
    }

    public void Windowed()
    {
        if (Screen.fullScreen)
            Screen.fullScreen = false;
    }
}
