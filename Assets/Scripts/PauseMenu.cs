using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public SceneFader sceneFader;
    public GameObject ui;
    public Button btn;
    public Button jumpButton;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {

        btn.interactable = false;
        jumpButton.interactable = false;

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
            btn.interactable = true;
            jumpButton.interactable = true;
        }
    }
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
    }
    public void Continue()
    {
        Toggle();
    }
}
