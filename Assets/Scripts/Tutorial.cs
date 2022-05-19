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


    public void Update()
    {

    }
    public void Awake()
    {
        PauseMenu.isPaused = true;
        tutorialUI.SetActive(true);
        height = Screen.currentResolution.height;
        width = Screen.currentResolution.width;
        left.sizeDelta = new Vector2(width / 3, height);
        right.sizeDelta = new Vector2(width / 3, height);
        center.sizeDelta = new Vector2(width / 3, height);
    }
    public void Hide()
    {
        tutorialUI.SetActive(false);
        btn.SetActive(false);
        StartCoroutine(Time());
        


    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(0.6f);
        PauseMenu.isPaused = false;
    }

}
