using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;

    public GameObject completeLevelUI;


    // Start is called before the first frame update
    public static bool isGameEnded = false;
    void Awake()
    {
        isGameEnded = false;
    }
    void Update()
    {
        if (isGameEnded)
        {
            return;
        }
        if (Input.GetKey("e"))
        {
            EndGame();
        }
    }
    void EndGame()
    {
        isGameEnded = true;
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        GameAnalyticsInit.OnCoinPickup("Coins: ", Score.coins);
        completeLevelUI.SetActive(true);
        GameAnalyticsInit.OnLevelComplete("1");
    }


}
