using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
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

    
    //Buttons Scripts & SpriteRenderers
    public MonoBehaviour TButton;
    public MonoBehaviour SButton;
    public MonoBehaviour CButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Starts game controlling Head
        SplayerScript.enabled = true; 
        TplayerScript.enabled = false; 
        CplayerScript.enabled = false;
    }

    // Update is called once per frame
            
    void Update()
    {
        
        
        //Controls Triangle
        if (Input.GetKeyDown(Tplayer1keyCode))
        {
            TplayerScript.enabled = true;
            SplayerScript.enabled = false;
            CplayerScript.enabled = false;
        }

        //Controls Square
        if (Input.GetKeyDown(Splayer2keyCode))
        {
            TplayerScript.enabled = false;
            SplayerScript.enabled = true;
            CplayerScript.enabled = false;
        }

        // Controls Circle
        if (Input.GetKeyDown(Cplayer3keyCode))
        {
            TplayerScript.enabled = false;
            SplayerScript.enabled = false;
            CplayerScript.enabled = true;
        }
    }
    
    
}

      