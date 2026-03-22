using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class BulletScrip : MonoBehaviour
{
    //Rigidbody variable and component
    public Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        //The velocity of bullet when created on x-axis
        rb.linearVelocity = new Vector3(5, 0,0);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {   
        //If what the bullet collides into has this tag, destroy that tagged item and the bullet or else just destroy the bullet
        if (collision.gameObject.CompareTag("BulletWall"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    }
}

