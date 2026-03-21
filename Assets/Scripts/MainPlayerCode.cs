using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainPlayerCode : MonoBehaviour

{
    //Assigning #'s as inputs
    public KeyCode Tplayer1keyCode = KeyCode.Alpha1;
    public KeyCode Splayer2keyCode = KeyCode.Alpha2;
    public KeyCode Cplayer3keyCode = KeyCode.Alpha3;


    //Scripts for the Characters
    public MonoBehaviour TplayerScript;
    public MonoBehaviour SplayerScript;
    public MonoBehaviour CplayerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Control Triangle
        if (Input.GetKeyDown(Tplayer1keyCode))
        {
            TplayerScript.enabled = true;
            SplayerScript.enabled = false;
            CplayerScript.enabled = false;
        }

        //Control Square
        if (Input.GetKeyDown(Splayer2keyCode))
        {
            TplayerScript.enabled = false;
            SplayerScript.enabled = true;
            CplayerScript.enabled = false;
        }

        // Control Circle
        if (Input.GetKeyDown(Cplayer3keyCode))
        {
            TplayerScript.enabled = false;
            SplayerScript.enabled = false;
            CplayerScript.enabled = true;
        }
    }
}

      