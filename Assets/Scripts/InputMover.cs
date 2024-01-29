using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMover : MonoBehaviour
{

    public Vector3 FacingDirection { get { return facingRight ? Vector3.right : Vector3.left; } }

    Rigidbody2D rigitBod;   // accessing components of the player

    [SerializeField]
    private float speed = 1f;      // default player speed
    public bool facingRight;  // facing right or left
    [SerializeField] int jumpPower; // player jump power

    // all the directions the player can move
    [Tooltip("Button to move right")]
    [SerializeField]
    private KeyCode rightMove;     

    [Tooltip("Button to move left")]
    [SerializeField]
    private KeyCode leftMove;

    [Tooltip("Button to move up")]
    [SerializeField]
    private KeyCode upMove;

    [Tooltip("Button to pick up")]
    [SerializeField]
   // private KeyCode pickUp;     
     
    private bool isJumping = false;

    //private int direction;

    private void Start() 
    {
        rigitBod = GetComponent<Rigidbody2D>();
        
        // simple guidance about the keys
        //Debug.Log("These are the buttons: " + upMove +"," + leftMove +"," +rightMove +"," +throwKnife);    
    }
    void FixedUpdate() 
    {
        // up or down direction
        float horizontalMovement = 0;
        float verticalMovement = 0;

        // moves according to the key pressed
        if (Input.GetKey(rightMove))    // right
        {
            horizontalMovement = speed;
        }
        else if (Input.GetKey(leftMove))    // left
        {
            horizontalMovement = -speed;
        }

        if (!isJumping && Input.GetKey(upMove))       // jump
        {
            rigitBod.velocity = new Vector2(rigitBod.velocity.x, jumpPower);
        }

        // modifies the character location based on the key pressed
        // deltaTime - time in seconds it took from last frame to current
        // we change the x,y coordinate no need to edit z
        transform.position += new Vector3(horizontalMovement * Time.deltaTime, verticalMovement * Time.deltaTime, 0);

        Flip(horizontalMovement);   // flips the char when it moves right/left
    }

    private void Flip(float flip)
    {
        // flips the char when facing right/left by x scale 
        if (flip > 0 && !facingRight || flip < 0 && facingRight )
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}