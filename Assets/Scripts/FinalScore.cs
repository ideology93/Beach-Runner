using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text coinsCollected;
    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }
    IEnumerator AnimateText()
    {
        coinsCollected.text = "0";
        int coins = 0;
        yield return new WaitForSeconds(0.75f);
        while (coins < Score.coins)
        {
            coins++;
            coinsCollected.text = coins.ToString() + " / 87";

            yield return new WaitForSeconds(0.05f);
        }

    }
}
