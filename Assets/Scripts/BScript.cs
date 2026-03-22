using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;


public class BScript : MonoBehaviour
{
    public static int Gscore = 0;
    public GameObject gate;
    private bool Pressed = false;
    
        public void OnTriggerEnter(Collider player)
        {
            Debug.Log(gameObject.name + "touched" + player.gameObject.name);
            if (Pressed) return;
            
            if (gameObject.name == "Tbutton" && player.CompareTag("PlayerT"))
            {
                Pressed = true;
                Gscore++;
                Debug.Log("GScore:1 " + Gscore);
            }

            else if (gameObject.name == "Cbutton" && player.CompareTag("PlayerC"))
            {
                Pressed = true;
                Gscore++;
                Debug.Log("GScore:2 " + Gscore);
            }

            else if (gameObject.name == "Sbutton" && player.CompareTag("PlayerS"))
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
        

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
                
        }
    }
}
