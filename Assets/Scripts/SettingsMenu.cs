using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class SettingsMenu : MonoBehaviour
{
    public static bool isPaused;
    public SceneFader sceneFader;
    public GameObject ui;
    public Button btn;
    public Light lights;


    public AudioSource audioSource;
    public Camera cam;
    public GameObject postProcessing;


    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }


    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual, true);
        Debug.Log(QualitySettings.GetQualityLevel());
        switch (qual)
        {
            case 1:
                cam.farClipPlane = 50;
                postProcessing.GetComponent<Volume>().weight = 0;
                break;
                lights.shadows = LightShadows.None;
            case 2:
                cam.farClipPlane = 80;
                postProcessing.GetComponent<Volume>().weight = 0.5f;
                lights.shadows = LightShadows.None;
                break;
            case 3:
                cam.farClipPlane = 120;
                postProcessing.GetComponent<Volume>().weight = 1f;
                lights.shadows = LightShadows.Hard;
                break;


        }
    }
    public void Toggle()
    {
        btn.interactable = false;
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
