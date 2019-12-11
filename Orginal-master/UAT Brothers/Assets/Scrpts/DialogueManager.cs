using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    //creates a text box
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine;

    private Player theplayer;

    // Start is called before the first frame update
    void Start()
    {
        //finds the player 
        theplayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the player hits the down arrow the dialouge box will pop up
        if (dialogActive && Input.GetKeyDown(KeyCode.DownArrow))
        {
            //dBox.SetActive(false);
            //dialogActive = false;

            currentLine++;
        }
        if(currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;
            theplayer.canMove = true;
        }
        dText.text = dialogLines[currentLine];
    }
    //shows the dialouge in inspector that you can edit
    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        theplayer.canMove = false;
    }
}
