using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] public ParticleSystem particleSystem;

    private void Start()
    {
        Debug.Log(particleSystem);
    }

    public int getLevel()
    {
        return level;
    }

    public void increaseLevel()
    {
        level += 1;
    }   
}
