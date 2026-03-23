using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;


public class BScript : MonoBehaviour
{
    //Gscore is static so that its shared amongst the buttons, button trigger 'pressed'
    public static int Gscore;
    public GameObject gate;
    private bool Pressed;

    //SpriteR's for buttons (to turn green)
    public SpriteRenderer BT;
    public SpriteRenderer BC;
    public SpriteRenderer BS;
    //For enemy variable and components
    public GameObject Enemy;
    private bool enemyspawn;
   // public string StartScene2;

    public void OnTriggerEnter2D(Collider2D player)
    {
        //If pressed, can't be pressed again to conflict the score
        if (Pressed) return;

        //Each if and compare tag is so once the button is pressed by player it will add to score of gate leading to it 'opening' 
        if (gameObject.name == "TButton" && player.CompareTag("PlayerT"))
        {
            Pressed = true;
            Gscore++;
            //Debug.Log("GScore:1 " + Gscore);
            BT.color = Color.green;

        }
        else if (gameObject.name == "CButton" && player.CompareTag("PlayerC"))
        {
            Pressed = true;
            Gscore++;
            //Debug.Log("GScore:2 " + Gscore);
            BC.color = Color.green;
        }
        else if (gameObject.name == "SButton" && player.CompareTag("PlayerS"))
        {
            Pressed = true;
            Gscore++;
            //Debug.Log("GScore:3 " + Gscore);
            BS.color = Color.green;
        }

        //If gate score is greater or equal to 3 (buttons pressed) and the gate is present then destroy it
        if (Gscore >= 3)
        {
            if (gate != null)
            {
                Destroy(gate);
            }
        }
    }

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //At start score always 0
        Gscore = 0;
    }

    // Update is called once per frame
    void Update()
    {   //If theirs no gate and enemy has not spawned, isntantiate an enemy and make the spawn true
        if (gate == null && !enemyspawn)
        {
            Instantiate(Enemy, new Vector2(9.4f, 1.4f), Quaternion.identity);
            enemyspawn = true;
        }
    }

    
    
   //  private void OnCollisionEnter2D(Collision2D other)
    //{
  //      if (other.gameObject.CompareTag("Enemy"))
     //   {
   //         Restart();
      //  }
   // }

  //  public void Restart()
   // {
  //      SceneManager.LoadScene(StartScene2);
   // }
}

