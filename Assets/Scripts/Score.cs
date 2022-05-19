using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int coins;
    public TextMeshProUGUI scoreText;
    public void Awake()
    {
        coins = 0;
    }
    public void IncreaseScore()
    {
        coins++;
        scoreText.text = "" + coins;
    }
}
