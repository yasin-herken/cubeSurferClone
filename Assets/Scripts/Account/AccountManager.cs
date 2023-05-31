using System;
using System.Collections;
using System.Collections.Generic;
using HmsPlugin;
using HuaweiMobileServices.Id;
using HuaweiMobileServices.Utils;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    private readonly string TAG = "[HMS] AccountManager ";
    private const string NOT_LOGGED_IN = "No user logged in";
    private const string LOGGED_IN = "{0} is logged in";
    private const string LOGIN_ERROR = "Error or cancelled login";
    [SerializeField] private TMPro.TMP_Text DisplayName;


    public static Action<string> AccountKitLog;

    public static Action AccountKitIsActive;
    // Start is called before the first frame update
    void Start()
    {
        HMSAccountKitManager.Instance.OnSignInSuccess = OnLoginSuccess;
        HMSAccountKitManager.Instance.OnSignInFailed = OnLoginFailure;
        HMSAccountKitManager.Instance.SilentSignIn();
    }
    public void OnLoginSuccess(AuthAccount authHuaweiId)
    {
        AccountKitLog?.Invoke(string.Format(LOGGED_IN, authHuaweiId.DisplayName));
      
        AccountKitIsActive?.Invoke();
        //RealTimeDataStore.UserIsLoggedIn = true;
    }

    public void OnLoginFailure(HMSException error)
    {
        AccountKitLog?.Invoke(LOGIN_ERROR);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
