using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dMAn;

    public string[] dialogueLines;

    // Start is called before the first frame update
    void Start()
    {
        //Finds the dialouge manager at the beggining of the game
        dMAn = FindObjectOfType<DialogueManager>();
    }


   

    // Player enters the collider it will show dialouge whenever the player presses the down arrow
     void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                // dMAn.ShowBox(dialogue);

                if (!dMAn.dialogActive)
                {
                    dMAn.dialogLines = dialogueLines;
                    dMAn.currentLine = 0;
                    dMAn.ShowDialogue();

                }
            }
        }
    }
}
