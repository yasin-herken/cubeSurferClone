using System.Collections;
using System.Collections.Generic;
using HmsPlugin;
using HuaweiMobileServices.IAP;
using HuaweiMobileServices.Utils;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class IAPManager : MonoBehaviour
{
    private string diamond5 = "com.School.GemSurfer.diamond5";
    private string removeAds = "com.School.GemSurfer.removeAds";

    public static IAPManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        HMSIAPManager.Instance.InitializeIAP();
        HMSIAPManager.Instance.OnBuyProductSuccess += OnBuyProductSuccess;

        HMSIAPManager.Instance.OnInitializeIAPSuccess += OnInitializeIAPSuccess;
      //  HMSIAPManager.Instance.OnInitializeIAPFailure += OnInitializeIAPFailure;
    }


    public void PurchaseProduct(string productID)
    {
        Debug.Log($"PurchaseProduct");
        HMSIAPManager.Instance.PurchaseProduct(productID);
    }

  
       private void OnInitializeIAPSuccess()
    {
        // IAP is ready
        Debug.Log("Success");
    }

    private void OnBuyProductSuccess(PurchaseResultInfo obj)
    {
        Debug.Log($"OnBuyProductSuccess");

        if (obj.InAppPurchaseData.ProductId == "removeAds")
        {
            GameController.Instance.removeAds = true;
        }
        else if (obj.InAppPurchaseData.ProductId == "diamond5")
        {
            GameController.Instance.setDiamond(GameController.Instance.getDiamond() + 5);
        }
    }
}
