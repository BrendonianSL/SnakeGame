using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This Script Designates And Controls All Input Given By The Player
public class PlayerInput : MonoBehaviour
{
    public float horizontal; //Variable Responsible For Horizontal Movement

    [Header("Script References")]
    [SerializeField] private PlayerMovement playerMovement;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void MyInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //Sets The Float Equal To Our Horizontal Input
        bool isGrounded = playerMovement.Grounded(); //Sets Local Ground Variable

        if(Input.GetButtonDown("Jump") && isGrounded) //If We Press Jump Key AND We Are Grounded
        {
            playerMovement.jumpRequested = true; //Calls The Jump Script On PlayerMovement
        }
    }
}
