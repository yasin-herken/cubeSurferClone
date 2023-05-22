using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdsInitializer instance;
    [SerializeField] string _androidGameId = "5284742";
    string _gameId;
    [SerializeField] bool _testMode = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        if (Advertisement.isInitialized)
        {
            Debug.Log("Advertisement is initilialized");
            LoadRewardedAd();
        }
        else
        {
            InitializeAds();
        }
    }

    void InitializeAds()
    {
        _gameId = _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initilization complete.");
        LoadInerstitialAd();
        LoadBannerAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void LoadInerstitialAd()
    {
        Advertisement.Load("Interstitial_Android", this);
    }

    public void LoadRewardedAd()
    {
        Advertisement.Load("Rewarded_Android", this);
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("OnUnityAdsShowFailure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("OnUnityAdsShowStart");
        Time.timeScale = 0;
        Advertisement.Banner.Hide();

    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("OnUnityAdsShowClick");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("OnUnityAdsShowCompleted" + showCompletionState);
        if (placementId.Equals("Rewarded_Android") && UnityAdsCompletionState.COMPLETED.Equals(showCompletionState))
        {
            Debug.Log("rewarded Player");
        }
        Time.timeScale = 1;
        Advertisement.Banner.Show("Banner_Android");
    }

    public void LoadBannerAd()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Load("Banner_Android",
            new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerError
            });
    }

    void OnBannerLoaded()
    {
        Advertisement.Banner.Show("Banner_Android");
    }

    void OnBannerError(string message)
    {

    }
}
