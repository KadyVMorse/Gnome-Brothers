using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameMaster : MonoBehaviour
{
    //The text and the intgers
    public int gems;
    public Text gemsText;
    public Text InputText;




    void Update()
    {
        //It will add +1 gems to the gems text 
        gemsText.text = ("Gems: " + gems);
    }

}
