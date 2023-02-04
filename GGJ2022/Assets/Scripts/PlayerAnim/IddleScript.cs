using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IddleScript : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (animator.gameObject.GetComponent<PlayerActions>().isPullingRoot)
        {
            Debug.Log("Pulling root");
            PlayerActions instance = animator.gameObject.GetComponent<PlayerActions>();
            animator.Play("Pulling");
        }

        if (animator.gameObject.GetComponent<PlayerActions>().isAttacking)
        {
            Debug.Log("Ataque1");
            PlayerActions instance = animator.gameObject.GetComponent<PlayerActions>();
            instance.Slash(1, "Slash1");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<PlayerActions>().isAttacking = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
