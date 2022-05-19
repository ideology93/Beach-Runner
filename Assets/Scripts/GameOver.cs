using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Update()
    {
        if (GameManager.isGameEnded)
        {
            gameOverUI.SetActive(true);
        }

    }
    public void Retry()
    {
        GameManager.isGameEnded = false;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
