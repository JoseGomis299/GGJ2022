using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingScript : StateMachineBehaviour
{

    private PlayerActions instance;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        instance =   animator.gameObject.GetComponent<PlayerActions>();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        if (Input.GetKeyDown("q"))
        {
            instance.lanzandoBola = true;
           
        }
        if (Input.GetKey("q") && instance.lanzandoBola)
        {
            instance.GetComponent<LineRenderer>().enabled = true;
            instance.trajectory.DrawTrajectory();
            instance.trajectory.Movements();
        }
        if (Input.GetKeyUp("q") && instance.lanzandoBola)
        {
            instance.lanzandoBola = false;
            instance.GetComponent<LineRenderer>().enabled = false;
            Destroy(instance.objGrabbed);
            instance.objGrabbed = null;
            instance.trajectory.Shoot();
            //instance.objGrabbed.GetComponent<Rigidbody2D>().AddForce(instance.gameObject.GetComponent<PlayerActions>().GrabPoint.up * instance.trajectory._force); //Add Force to instantiated object. FixedDeltaTime will need to be equated either here via ForceMode or in Velocity. You choose.
            //Debug.Log("Throwing");
            animator.SetTrigger("throwExit");
        }

        //if (instance.objGrabbed == null || instance.objGrabbed.GetComponent<Ball>().lanzada) return;
        //instance.GrabPoint.transform.position = new Vector3(instance.GrabOffset.transform.position.x,
        //    instance.GrabOffset.transform.position.y, instance.GrabOffset.transform.position.z);
        //instance.objGrabbed.transform.localPosition = new Vector3(0,0,0);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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