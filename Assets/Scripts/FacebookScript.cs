using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System;

public class FacebookScript : MonoBehaviour
{
    public GameObject loginButton;
    public GameObject logoutButton;
    public GameObject shareButton;
    public GameObject requestButton;

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();

                else
                    Debug.LogError("Couldn't initialize");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
            FB.ActivateApp();
    }

    #region Login / Logout
    public void FacebookLogin()
    {
        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(permissions, AuthCallback);
    }
    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
                GameAnalyticsInit.OnFacebookLogin("User logged at : ", System.DateTime.Now.Hour);
            }
            loginButton.SetActive(false);
            logoutButton.SetActive(true);
            shareButton.SetActive(true);
            requestButton.SetActive(true);
        }
        else
        {
            Debug.Log("User cancelled login");
        }

    }

    public void FacebookLogout()
    {
        FB.LogOut();
        loginButton.SetActive(true);
        logoutButton.SetActive(false);
        shareButton.SetActive(false);
        requestButton.SetActive(false);
    }
    #endregion

    public void FacebookShare()
    {
        FB.ShareLink(
            new Uri("http://github.com/ideology93/Beach-Runner/"),

            callback: ShareCallback);
    }

    #region Inviting
    public void FacebookGameRequest()
    {
        FB.AppRequest("Hey, try this game!", title: "Beach Runner");
    }

    // public void FacebookInvite()
    // {
    //     FB.Mobile.AppInvite(new System.Uri("https://play.google.com/store/apps/details?id=com.tappybyte.byteaway"));
    // }
    #endregion
    public void Init()
    {
        FB.Init();
        FB.ActivateApp();
    }
    private void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error: " + result.Error);
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        }
        else
        {
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
        }

    }
}