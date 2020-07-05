using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauzeMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                BackToGame();
            }
            else
            {
                PauseGame();
            }

        } 
    }

    public void PauseGame()
    {
        pauzeMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackToGame()
    {
        pauzeMenu.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QQUIT");

    }
}
