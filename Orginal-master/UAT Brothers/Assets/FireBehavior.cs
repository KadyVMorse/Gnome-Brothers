using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : StateMachineBehaviour
{
    //declares the floats
    public float timer;
    public float miniTime;
    public float maxTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   // will randolmoly play after a certain time and will find olayer to attack and follow
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(miniTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //wil play  dash  after certain amount of time 

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(timer <= 0)
        {
            animator.SetTrigger("dash");
        }
       //if the random picks fire then it will contunie to play animation
        else
        {
            timer -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //moves the boss
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

   
}
