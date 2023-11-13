using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script Handles All Player Related Movement
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [Tooltip("Handles the speed at which the player moves")]
    [SerializeField] private float movementSpeed;
    [Tooltip("Handles The Force At Which We Jump")]
    [SerializeField] private float jumpForce;
    [Tooltip("What Layer Is Considered To Be Ground?")]
    [SerializeField] private LayerMask groundLayer;
    [HideInInspector] public bool jumpRequested;

    [Header("Object References")]
    [Tooltip("References Our GroundCheck Object Transform")]
    [SerializeField] private Transform groundCheck;
    [Tooltip("Direct Reference To Player's Rigidbody")]
    [SerializeField] private Rigidbody2D rb;
    [Tooltip("Direct Reference To Player Aniamtor")]
    public Animator animator;

    [Header("Script References")]
    [Tooltip("Direct PlayerInput Script Reference")]
    [SerializeField] private PlayerInput playerInput;

    // Update is called once per frame
    void Update()
    {
        playerInput.MyInput(); //This Runs Everything In My Input Every Second
    }

    private void FixedUpdate() //This Function Is Proper For Any Physics Related Manipulation
    {
        rb.velocity = new Vector2(playerInput.horizontal * movementSpeed, rb.velocity.y); //Moves Character
        
        if(jumpRequested) //If We Requested To Jump
        {
            //This Function Is Called In Fixed Update So It Stays Consistent With All Forces
            Jump(); //Calls Jump Function
            //We No Longer Need To Request It Again
            jumpRequested = false;
        }

    }

    public void Jump() //Function That Handles Jumping
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); //Sets Jump Force
    }

    public bool Grounded() //Boolean Function For Ground Checking
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //Creates A Circle Check To See If We Are On The Ground
    }


}
