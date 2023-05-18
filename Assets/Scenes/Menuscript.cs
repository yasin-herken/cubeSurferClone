using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menuscript : MonoBehaviour
{
    
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
