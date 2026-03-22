using UnityEngine;
using UnityEngine.SceneManagement;

public class TPlayerScript : MonoBehaviour

{
    public Rigidbody2D PRB;
    public float WalkSpeed = 10f;
    public Vector2 movement;

    private float DashTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

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

        movement = new Vector2(moveX, moveY).normalized;

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

    void FixedUpdate()
    {
   //     PRB.linearVelocity = movement * WalkSpeed;
    }
}