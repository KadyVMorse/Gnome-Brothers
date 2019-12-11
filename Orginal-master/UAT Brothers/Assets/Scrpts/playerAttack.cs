using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    //created a timer so player couldn't spam attacking
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;



    void Update()
    {
        //if there is no restranits then the player wiill attack
        if (timeBtwAttack <= 0)
        {
            //Then player willl attack
            if (Input.GetKey(KeyCode.Backspace))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Boss>().TakeDamage(damage);
                }
            }timeBtwAttack = startTimeBtwAttack;
        }
        //The timer will stop the player from attacking 
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }
    //creates a gizmo in inspector so you edit the attack range and postion
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
