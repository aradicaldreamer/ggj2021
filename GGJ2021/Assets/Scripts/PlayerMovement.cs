using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private Vector2 playerMovement;
    [SerializeField] private GameObject flashlight;
    
    [Header("AI")] 
    [SerializeField] private bool isWanderingAI = false;
    [SerializeField] private bool isSetPathAI = false;
    private int currentTargetNumber = 0;
    [SerializeField] private Transform[] aiNavigationTargets;
    private Vector2 setPathDirection;
    private Vector2 wanderMovement;
    [SerializeField] private float wanderUpdateFrequency = 1.0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if(rb == null)
        {
            Debug.Log("No Rigidbody2D Component attached to Player object!");
        }
        if(animator == null)
        {
            Debug.Log("No Animator attached to Player object!");
        }
        if (isSetPathAI && (aiNavigationTargets == null || aiNavigationTargets.Length == 0))
        {
            Debug.Log(this.name + " is set to follow a path but has no targets!");
        }
        StartCoroutine(AIWanderCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (isWanderingAI)
        {
            AnimatePlayer(wanderMovement);
        }
        else
        {
            PlayerControls();   
        }
    }

    void FixedUpdate()
    {
        if(isWanderingAI)
        {
            MoveCharacter(wanderMovement);
        }
        else if (isSetPathAI && aiNavigationTargets != null) 
        {
            MoveCharacterOnSetPath(aiNavigationTargets[currentTargetNumber]);
        }
        else
        {
            MoveCharacter(playerMovement);
        }
    }

    IEnumerator AIWanderCoroutine()
    {
        while (isWanderingAI)
        {
            wanderMovement = Random.insideUnitCircle;
            yield return new WaitForSeconds(wanderUpdateFrequency);
        }
    }

    private void PlayerControls()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        AnimatePlayer(playerMovement);
    }

    void MoveCharacter(Vector2 movement)
    {
        if(rb == null)
        {
            Debug.Log("No Rigidbody2D Component attached to Player object!");
            return;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void MoveCharacterOnSetPath(Transform targetTransform)
    {
        // Debug.Log("Moving Character at position " + rb.position.ToString() + " towards target at position " + targetTransform.position.ToString());
        // setPathDirection = new Vector2(targetTransform.position.x -rb.position.x, targetTransform.position.y - rb.position.y);
        // float moveDistance = moveSpeed * Time.fixedDeltaTime;
        // Debug.Log("Distance to target");
        // if (setPathDirection > moveDistance)
        // {
        //     rb.MovePosition(rb.position + vectorToTarget.normalized *moveDistance);
        // }
        // else
        // {
        //     Debug.Log("Setting next target");
        //     currentTargetNumber ++;
        //     if (currentTargetNumber > aiNavigationTargets.Length) currentTargetNumber = 0;
        // } 
    }

    private void UpdateFlashlightRotation()
    {
        if (flashlight == null) return;
        
    }

    private void AnimatePlayer(Vector2 movement)
    {
        if(animator == null)
        {
            Debug.Log("No Animator attached to Player object!");
            return;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
