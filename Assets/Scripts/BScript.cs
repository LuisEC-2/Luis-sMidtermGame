using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;


public class BScript : MonoBehaviour
{
    public static int Gscore;
    public GameObject gate;
    private bool Pressed;
    private bool Vicinity;

    public void OnTriggerEnter2D(Collider2D player)
    {
        Debug.Log("CHECK -> My name: [" + gameObject.name + "] | Player Tag: [" + player.tag + "]");
        if (Pressed) return;

        if (gameObject.name == "TButton" && player.CompareTag("PlayerT"))
        {
            Pressed = true;
            Gscore++;
            Debug.Log("GScore:1 " + Gscore);
        }

        else if (gameObject.name == "CButton" && player.CompareTag("PlayerC"))
        {
            Pressed = true;
            Gscore++;
            Debug.Log("GScore:2 " + Gscore);
        }

        else if (gameObject.name == "SButton" && player.CompareTag("PlayerS"))
        {
            Pressed = true;
            Gscore++;
            Debug.Log("GScore:3 " + Gscore);
        }

        if (Gscore >= 3)
        {
            if (gate != null)
            {
                Destroy(gate);
            }
        }

        if (gameObject.name == "Pathway" && player.CompareTag("PlayerS") && player.CompareTag("PlayerT") && player.CompareTag("PlayerC"))
        {
            Vicinity = true;
            SceneManager.LoadScene("Scenes/To Be Continued");
        }
    }

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Gscore = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

