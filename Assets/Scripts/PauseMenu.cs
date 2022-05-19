using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public SceneFader sceneFader;
    public GameObject ui;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);   

        if (ui.activeSelf)
        {
            isPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
        }
    }
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);

    }

    public void Menu()
    {

        Toggle();
    }
    public void Continue()
    {
    Toggle();
    }
}
