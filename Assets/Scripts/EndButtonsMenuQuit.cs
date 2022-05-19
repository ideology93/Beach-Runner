using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndButtonsMenuQuit : MonoBehaviour
{
    private bool isRunning = true;
    public SceneFader sceneFader;
    public TextMeshProUGUI text;
    private string end = "Thank you for trying the Demo!";
    private float typingSpeed = 0.1f;
    public GameObject menuButton;
    public GameObject quitButton;



    void Update()
    {
        if (isRunning)
        {

            isRunning = false;
            if (text.text != end)
            {
                StartCoroutine(DisplayText());
            }
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
    }
    IEnumerator DisplayText()
    {
        foreach (char letter in end.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

}
