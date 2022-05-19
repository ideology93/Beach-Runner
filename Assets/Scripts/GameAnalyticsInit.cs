using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;


public class GameAnalyticsInit : MonoBehaviour
{
    public static GameAnalyticsInit instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        GameAnalytics.Initialize();

    }
    public static void OnLevelComplete(string level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "World_01", level, Score.coins);
    }

    public static void OnCoinPickup(string eventName, int eventValue)
    {
        GameAnalytics.NewDesignEvent(eventName, eventValue);
    }
    public static void OnFacebookLogin(string eventName, int time){
        GameAnalytics.NewDesignEvent(eventName, time);
    }
}
