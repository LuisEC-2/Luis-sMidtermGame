using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{
public Rigidbody2D PRB;
public float WalkSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PRB.linearVelocity = new Vector2(0, WalkSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PRB.linearVelocity = new Vector2(0, -WalkSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PRB.linearVelocity = new Vector2(WalkSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PRB.linearVelocity = new Vector2(-WalkSpeed, 0);
        }
        else
        {
            PRB.linearVelocity = new Vector2(0, 0);
        }


    }
    
}
