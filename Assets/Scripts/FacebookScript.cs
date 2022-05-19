using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FacebookScript : MonoBehaviour
{

    public Text FriendsText;

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
        }
        else
        {
            Debug.Log("User cancelled login");
        }

    }

    public void FacebookLogout()
    {
        FB.LogOut();
    }
    #endregion

    public void FacebookShare()
    {
        FB.ShareLink(new System.Uri("Beach Runner"), "Check it out!",
            "Test game",
            new System.Uri("https://dogeseed.com/doge.2214a63a.svg"));
    }

    #region Inviting
    public void FacebookGameRequest()
    {
        FB.AppRequest("Hey, try this game!", title: "Beach Runner Test");
    }

    // public void FacebookInvite()
    // {
    //     FB.Mobile.AppInvite(new System.Uri("https://play.google.com/store/apps/details?id=com.tappybyte.byteaway"));
    // }
    #endregion


}