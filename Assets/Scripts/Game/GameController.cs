using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] public ParticleSystem particleSystem;
    public TMP_Text diamondTxt;
    private int diamond = 0;
    public static GameController instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public int getLevel()
    {
        return level;
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
}
