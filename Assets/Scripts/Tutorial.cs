using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public RectTransform left;
    public RectTransform center;

    public RectTransform right;
    private int height;
    private int width;
    public GameObject tutorialUI;
    public GameObject btn;
    public Button jump;



    public void Awake()
    {
        PauseMenu.isPaused = true;
        tutorialUI.SetActive(true);
        jump.interactable = false;

    }
    public void Hide()
    {

        tutorialUI.SetActive(false);
        btn.SetActive(false);
        jump.interactable = true;
        StartCoroutine(Time());
        
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(0.6f);
        PauseMenu.isPaused = false;
    }

}
