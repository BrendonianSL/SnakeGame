using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Opponents are moving like a pingpong

public class OpponentsMove : MonoBehaviour{
    public float speed;
    public float distance;
    private Vector3 startPosition;
    private bool movingToRight = true;

    private SpriteRenderer spriteRenderer;
    private GameController gameController;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        gameController = FindObjectOfType<GameController>();
    }
    

    void Update(){
        if(gameController != null && gameController.isGameover){ 
            speed = 0f;
        }else{
            float currentPosition = transform.position.x + (movingToRight ? speed : -speed) * Time.deltaTime;
            transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);

            if (currentPosition > startPosition.x + distance && movingToRight){
                ChangeDirection();
            }else if (currentPosition < startPosition.x && !movingToRight){
                ChangeDirection();
            }
        }
    }


    void ChangeDirection(){
            movingToRight = !movingToRight;
            spriteRenderer.flipX = !movingToRight;
    }  


}



