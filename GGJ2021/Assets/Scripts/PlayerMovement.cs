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
    [SerializeField] private FieldOfView fov;
    
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
        if (fov != null)
        {
            Vector3 aimDirection = new Vector3(wanderMovement.x, wanderMovement.y, 0);
            //Vector3 aimDirection = (targetPosition - transform.position.normalized);
            fov.SetAimDirection(aimDirection);
            fov.SetOrigin(transform.position);
        }
        if (isWanderingAI)
        {
            AnimatePlayer(wanderMovement);
        }
        else
        {
            PlayerControls();   
        }
    }

    Vector3 GetMouseWorldPosition() {
            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }

        Vector3 GetMouseWorldPositionWithZ() {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }
        Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
        }
        Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

    private void UpdateFOVRotation(Vector2 movement)
    {
        float rads = Mathf.Atan2(movement.y, movement.x);
        float degrees = rads * Mathf.Rad2Deg;

        fov.transform.localPosition = new Vector3(Mathf.Cos(rads) * 1, Mathf.Sin(rads) * 1, 0);
        fov.transform.localEulerAngles = new Vector3(0, 0, degrees - 90);
        
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
