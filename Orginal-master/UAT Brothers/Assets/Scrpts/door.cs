using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    //Loads to level 
    public int LevelToLoad;
    private gameMaster gm;

    

    void Start()
    {
        //Finds the gamemaster tag 
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    { //Looks for Player to enter the trigger box 
        if (col.CompareTag("Player"))
        {
            //Text Displayed when Player Enters triiger box
            gm.InputText.text = ("[c] Adventure");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Looks for Player to enter the trigger box 
        if (col.CompareTag("Player"))
        {
            //Text Displayed while player is in the Trigger box
            if (Input.GetKeyDown("c"))
            {
                //Loads Level
                Application.LoadLevel(LevelToLoad);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //Looks for Player to enter the trigger box 
        if (col.CompareTag("Player"))
        {
            //Text when player is outside trigger box
            gm.InputText.text = ("");
        }

    }
}


