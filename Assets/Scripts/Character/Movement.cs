using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    [SerializeField] private InputController inputController;

    [SerializeField] private float forwardMovementSpeed = 0.5f;

    [SerializeField] private float horizontalMovementSpeed = 4f;

    [SerializeField] private Animator animator;

    private float newPositionX;

    public float getForwardMovementSpeed()
    {
        return forwardMovementSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        inputController = GetComponent<InputController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameController.Instance.gameState == GameController.GameState.playing)
        {
            setCharacterMovementForward();
            setCharacterHorizontalMovement();
        } 
    }

    private void setCharacterMovementForward()
    {
        transform.Translate(Vector3.forward * getForwardMovementSpeed() * Time.deltaTime);
    }

    private void setCharacterHorizontalMovement()
    {
        newPositionX = transform.position.x + inputController.getHorizontalValue() * horizontalMovementSpeed * Time.fixedDeltaTime;
        if(newPositionX>= 0.091f)
        {
            newPositionX = 0.091f;
        } else if(newPositionX<= -0.107f)
        {
            newPositionX = -0.107f;
        }
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag== "Obstacle")
        {
            forwardMovementSpeed = 0f;
            GameController.Instance.gameState = GameController.GameState.die;
            AnimatorManager.Instance.setAnimator(AnimatorManager.AnimationState.Dying);
            StartCoroutine(ExecuteAfterTime(2));
            GameController.Instance.openShowPanel();  
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
    }

    //void reset()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

}