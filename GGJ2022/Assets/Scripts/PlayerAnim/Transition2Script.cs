using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition2Script : StateMachineBehaviour
{
    private PlayerController controller;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.transform.GetComponent<PlayerController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.GetComponent<PlayerActions>().isAttacking && animator.gameObject.GetComponent<PlayerActions>().hitEnemy)
        {
            Debug.Log("Ataque 3");
            PlayerActions instance = animator.gameObject.GetComponent<PlayerActions>();
            instance.Slash(3, "Slash3");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.isReallyAtacking = false;

        animator.gameObject.GetComponent<PlayerActions>().isAttacking = false;
        PlayerActions instance = animator.gameObject.GetComponent<PlayerActions>();


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
