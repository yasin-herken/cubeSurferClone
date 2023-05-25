using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menuscript : MonoBehaviour
{

    private void Start()
    {
        AdsInitializer.Instance.ShowInterstitialAd();
    }
    public void PlayButton()
    {
       SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Debug.Log("Oyundan çıktık!!");
        Application.Quit();
    }
}
