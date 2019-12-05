using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Player player;

  
    void Start()
    {
        //calls player tag 
        player = gameObject.GetComponentInParent<Player>();
    }

    //if the grouncheck hits the trigger than its grounded
    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }

    // if the groundcheck is in the trigger it is true
    void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }
    //if the groundcheck is out of the trigger than the player is not grounded
    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }
}


