using System;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private StackController stackController;

    private Vector3 direction = Vector3.back;
    private bool isStack = false;
    // Start is called before the first frame update
    void Start()
    {
        stackController = GameObject.FindObjectOfType<StackController>();
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cube")
        {
            if (!isStack)
            {
                isStack = !isStack;
                stackController.increaseBlockState(gameObject);
                SetDirection();
            }
        }

        if(other.gameObject.tag == "Obstacle")
        {
            stackController.decreaseBlockState(gameObject);
        }
    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
