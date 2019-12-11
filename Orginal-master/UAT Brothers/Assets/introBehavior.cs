using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introBehavior : StateMachineBehaviour
{
    private int rand;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //sets the randomizer to randomly play between two animations
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);
        if(rand == 0)
        {
            animator.SetTrigger("fire");
        }
        else
        {
            animator.SetTrigger("dash");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

 

 
}
