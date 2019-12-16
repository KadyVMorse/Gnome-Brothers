using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
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
        FindObjectOfType<AudioManager>().Play("Mini");
        // On triger with the spikes the player will take 1 damage and move 
        if (col.CompareTag("Player"))
        {
            player.Damage(2);

            StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
        }
    }
}
