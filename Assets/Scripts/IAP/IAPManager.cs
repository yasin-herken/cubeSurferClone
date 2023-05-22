using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class IAPManager : MonoBehaviour
{
    private string diamond5 = "com.School.GemSurfer.diamond5";
    private string removeAds = "com.School.GemSurfer.removeAds";


    public void OnPurchaseComplete(Product product)
    {
        Debug.Log(product.definition.id);
        if(product.definition.id.Equals(removeAds))
        {
            Debug.Log("");
        }
    }


    public void OnPurchaseFailed(Product i, PurchaseFailureDescription p)
    {
        Debug.Log(i.definition.id + " failed because " + p);
    }


}
