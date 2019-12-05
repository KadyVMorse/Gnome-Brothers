using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    

    
    //finds the player 
    private Player player;

    void Start()
    {
        //finds the player tag 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // On triger with the spikes the player will take 3 damage and move 
        if (col.CompareTag("Player"))
        {
            player.Damage(3);

            StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
        }
    }
}
