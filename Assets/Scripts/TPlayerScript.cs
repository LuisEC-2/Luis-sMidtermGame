using UnityEngine;
using UnityEngine.SceneManagement;

public class TPlayerScript : MonoBehaviour

{
    public Rigidbody2D PRB;
    public float WalkSpeed = 10f;
    public Vector2 movement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

        movement = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        PRB.linearVelocity = movement * WalkSpeed;
    }
}