using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
        playing,
        die,
        idle,
    }
    [SerializeField] private int level = 1;
    [SerializeField] public ParticleSystem particleSystem;
    public GameState gameState { get; set; }
    public GameObject showPanel;
    public TMP_Text diamondTxt;
    private int diamond = 0;
    public bool showPanelControl= false;
    public bool removeAds = false;
    public static GameController Instance { get; private set; }

    void OnEnable()
    {
        gameState = GameState.idle;
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        closeShowPanel();
    }

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
        AnimatorManager.Instance.setAnimator(AnimatorManager.AnimationState.Idle);
        AdsInitializer.Instance.ShowInterstitialAd();
        AnimatorManager.Instance.setAnimator(AnimatorManager.AnimationState.Running);
        gameState = GameState.playing;
    }
    
    public int getLevel()
    {
        return level;
    }

    public void openShowPanel()
    {
        showPanel.SetActive(true);
    }

    public void closeShowPanel()
    {
        showPanel.SetActive(false);
    }

    public void increaseLevel()
    {
        level += 1;
    }

    public void setDiamond(int number)
    {
        diamond += number;
    }
    public int getDiamond()
    {
        return diamond;
    }
    public void setPrint()
    {
        diamondTxt.SetText("Diamond: " + diamond);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
