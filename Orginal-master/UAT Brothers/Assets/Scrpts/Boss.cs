using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;


    public Animator camAnim;
    public Slider healthBar;
    private Animator anim;
    public bool isDead;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Dragon");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Plays stage two if the health is lower than 25
        if (health <= 25)
        {
            anim.SetTrigger("stageTwo");
        }
        //Plays death animation if there iis no health
        if (health <= 0)
        {
             anim.SetTrigger("death");
         }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }
        //gives the health bar a value
        healthBar.value = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the player damage ! 
        if (other.CompareTag("Player") && isDead == false)
        {
            if (timeBtwDamage <= 0)
            {
                camAnim.SetTrigger("shake");
                other.GetComponent<Player>().curHealth -= damage;
            }
        }
    }
    
        public void TakeDamage (int damage)
    {
        //it will take damage from the player
        health -= damage;
        
    }
}
