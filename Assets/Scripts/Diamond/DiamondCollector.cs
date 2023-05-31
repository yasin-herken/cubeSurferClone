using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiamondCollector : MonoBehaviour
{
   public int NumberOfDiamonds { get; private set; }
    public UnityEvent<DiamondCollector> OnDiamondCollected;

    public void DiamondCollected()
    {   
        GameController.Instance.setDiamond(GameController.Instance.getDiamond() + 1);
        NumberOfDiamonds = GameController.Instance.getDiamond();
        OnDiamondCollected.Invoke(this);
        //Debug.Log(NumberOfDiamonds);
    
    }
}
