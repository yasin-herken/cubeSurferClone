using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineController : MonoBehaviour
{

    private GameController gameController;
    private bool passed = false;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.FindObjectOfType<GameController>();
        gameController.particleSystem.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Animasyon will be added
        if(!passed)
        {
            if (other.tag == "cube")
            {
                passed = true;
                gameController.increaseLevel();
                gameController.particleSystem.Stop();
                if(gameController.particleSystem.isStopped)
                {
                    gameController.particleSystem.Play();
                }
                Invoke("level2", 2f);
            }
        }
       
        
    }
    void level2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
