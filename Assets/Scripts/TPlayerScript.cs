using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;


public class TPlayerScript : MonoBehaviour

{
    //Walkspeed + movement variable and components
    public Rigidbody2D PRB;
    public float WalkSpeed = 10f;
    public Vector2 movement;

    //Dashtimer float variable
    private float DashTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    //So players can't fling eachother
    void OnCollisionStay2D(Collision2D bodypart)
    {
        if (bodypart.gameObject.tag == "PlayerT")
        {
            PRB.linearVelocity = Vector2.zero;
        }
        if (bodypart.gameObject.tag == "PlayerS")
        {
            PRB.linearVelocity = Vector2.zero;
        }
        if (bodypart.gameObject.tag == "PlayerC")
        {
            PRB.linearVelocity = Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        // For movement + Diagonal movement
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        
        //Normalized makes movement more 'crisp' via vector math
        movement = new Vector2(moveX, moveY).normalized;
        
        //Dashtimer, if it has time left on it keep dash, once it does not stop 
        //Press space once to dash lasting .1f and sped of 25f 
        if (DashTimer > 0)
        {
            DashTimer -= Time.deltaTime;
        }
        else
        {
            PRB.linearVelocity = movement * WalkSpeed;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DashTimer = 0.1f;
            float Dash = 25f;
            PRB.linearVelocity = (movement.normalized * Dash);
        }
    }
    
    //Unity physics for better movement
    void FixedUpdate()
    {  
   //  PRB.linearVelocity = movement * WalkSpeed; // This messes with dash
    }
}