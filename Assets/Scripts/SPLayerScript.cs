using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class SPlayerScript : MonoBehaviour

{
    //Walkspeed + movement variableand components
    public Rigidbody2D PRB;
    public float WalkSpeed = 10f;
    public Vector2 movement;

    //Bullet call variable and prefab
    public BulletScrip BulletPrefab;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    //So players can't fling eachother
    void OnCollisionStay2D(Collision2D bodypart)
    {
        if (bodypart.gameObject.tag == "PlayerS")
        {
            PRB.linearVelocity = Vector2.zero;
        }
        if (bodypart.gameObject.tag == "PlayerT")
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

        //Press space to create bullet clones right of player position
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(BulletPrefab, transform.position+new Vector3(1f,0,0), Quaternion.identity);
        }
    }

    //Unity physics for better movement
    void FixedUpdate()
    {  
        PRB.linearVelocity = movement * WalkSpeed;
    }
}