using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private Vector2 movement;

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
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlayerControls()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        AnimatePlayer();
    }

    private void MovePlayer()
    {
        if(rb == null)
        {
            Debug.Log("No Rigidbody2D Component attached to Player object!");
            return;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void AnimatePlayer()
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
