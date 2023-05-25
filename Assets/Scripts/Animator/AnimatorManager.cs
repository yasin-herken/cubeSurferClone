using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public enum AnimationState
    {
        Idle,
        Running,
        Dying
    }
    public static AnimatorManager Instance { get; private set; }

    [SerializeField] public Animator animator;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void setAnimator(AnimationState animationState)
    {
        animator.Play(animationState.ToString());
    }
    
}
