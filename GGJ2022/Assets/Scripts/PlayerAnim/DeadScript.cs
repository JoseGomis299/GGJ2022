using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScript : StateMachineBehaviour
{
    private PlayerActions instance;
    private Trajectory trajectory;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        instance =   animator.gameObject.GetComponent<PlayerActions>();
        trajectory = animator.gameObject.GetComponent<Trajectory>();
        if (PlayerActions.Instance.objGrabbed != null)
        {
            instance.lanzandoBola = false;
            instance.GetComponent<LineRenderer>().enabled = false;
            trajectory.sphere.GetComponent<Ball>().lanzada = true;
            Destroy(instance.objGrabbed);
            instance.objGrabbed = null;
            instance.trajectory.Shoot();
            //instance.objGrabbed.GetComponent<Rigidbody2D>().AddForce(instance.gameObject.GetComponent<PlayerActions>().GrabPoint.up * instance.trajectory._force); //Add Force to instantiated object. FixedDeltaTime will need to be equated either here via ForceMode or in Velocity. You choose.
            //Debug.Log("Throwing");
            animator.SetTrigger("throwExit");
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerController.Instance.health =  PlayerController.Instance.maxHealth;
        animator.transform.position = CheckPointController.Instance.GetCheckPointPosition();
        animator.ResetTrigger("throwExit");

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
