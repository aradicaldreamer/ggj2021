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
    
    [Header("AI")] 
    [SerializeField] private bool isAI;
    [SerializeField] private bool isWandering = false;
    [SerializeField] private Vector2 wanderMovement;
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
        StartCoroutine(AIWanderCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (isAI)
        {
            AIControls();
        }
        else
        {
            PlayerControls();   
        }
    }

    void FixedUpdate()
    {
        if(isWandering)
        {
            MoveCharacter(wanderMovement);
        }
        else
        {
            MoveCharacter(playerMovement);
        }
    }

    private void AIControls()
    {
        AIWander();
    }

    private void AIWander()
    {
        AnimatePlayer(wanderMovement);
    }

    IEnumerator AIWanderCoroutine()
    {
        while (isWandering)
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

    private void MoveCharacter(Vector2 movement)
    {
        if(rb == null)
        {
            Debug.Log("No Rigidbody2D Component attached to Player object!");
            return;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
