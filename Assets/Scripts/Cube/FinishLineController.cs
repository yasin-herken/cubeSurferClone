using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineController : MonoBehaviour
{

    private bool passed = false;
    // Start is called before the first frame update

    void Start()
    {
        GameController.Instance.particleSystem.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Animasyon will be added
        if(!passed)
        {
            if (other.tag == "cube")
            {
                passed = true;
                if(!GameController.Instance.RemoveAds)
                {
                    AdsInitializer.Instance.HideBannerAd();
                }
                GameController.Instance.increaseLevel();
                
                GameController.Instance.particleSystem.Stop();
                if (GameController.Instance.particleSystem.isStopped)
                {
                    GameController.Instance.particleSystem.Play();
                }
                StartCoroutine(ExecuteAfterTime(2));
                if (!GameController.Instance.RemoveAds)
                {
                    AdsInitializer.Instance.ShowBannerAd();
                    AdsInitializer.Instance.ShowInterstitialAd();
                }
                Invoke("newLevel", 2f);
            }
        }
    }

    void newLevel()
    {
        SceneManager.LoadScene(2);
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
