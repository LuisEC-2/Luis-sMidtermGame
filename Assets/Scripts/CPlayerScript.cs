using UnityEngine;
using UnityEngine.SceneManagement;

public class CPlayerScript : MonoBehaviour

{
    public Rigidbody2D PRB;
    public float WalkSpeed = 10f;
    public Vector2 movement;
    
    public Vector2 StartScale;
    public Vector2 BigScale = new Vector2(3, 3);
    public bool Big = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartScale = transform.localScale;
        
    }

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

        movement = new Vector2(moveX, moveY).normalized;
        
        
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

    void FixedUpdate()
    {
        PRB.linearVelocity = movement * WalkSpeed;
    }
}