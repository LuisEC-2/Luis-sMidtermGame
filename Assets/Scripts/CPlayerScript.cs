using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class CPlayerScript : MonoBehaviour

{
    //Walkspeed + movement variable and components
    public Rigidbody2D PRB;
    public float WalkSpeed = 10f;
    public Vector2 movement;
    
    //Scale varaibles, a start size, a big size and a bool to notice when big is not in effect
    public Vector2 StartScale;
    public Vector2 BigScale = new Vector2(3, 3);
    public bool Big = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   //At game start make scale = mormal scale
        StartScale = transform.localScale;
    }
    //So players can't fling eachother
    void OnCollisionStay2D(Collision2D bodypart)
    {
        if (bodypart.gameObject.tag == "PlayerC")
        {
            PRB.linearVelocity = Vector2.zero;
        }
        if (bodypart.gameObject.tag == "PlayerT")
        {
            PRB.linearVelocity = Vector2.zero;
        }
        if (bodypart.gameObject.tag == "PlayerS")
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
        
        //Press space, to change scale to big, by applyting Bigscale when player is not big via bigsize mask
        //or else press space againt when player is big to go back to the normal scale size via default mask
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Big)
            {
                transform.localScale = BigScale;
                Big = false;
                gameObject.layer = LayerMask.NameToLayer("BigSize");
            }
            else
            {
                transform.localScale = StartScale;
                Big = true;
                gameObject.layer = LayerMask.NameToLayer("Default");
            }
            
        }
    }
    
    //Unity physics for better movement
    void FixedUpdate()
    { 
        PRB.linearVelocity = movement * WalkSpeed;
    }
}