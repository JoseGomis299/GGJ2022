using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingScript : StateMachineBehaviour
{

    private PlayerActions instance;
    private bool lanzando = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    instance =   animator.gameObject.GetComponent<PlayerActions>();
<<<<<<< HEAD
<<<<<<< HEAD
=======
        lanzando = false;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        lanzando = false;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
<<<<<<< HEAD
<<<<<<< HEAD
=======
        

>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        

>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
        if (Input.GetKeyDown("z"))
        {
            lanzando = true;
           
        }
        if (Input.GetKey("z") && lanzando)
        {
            instance.GetComponent<LineRenderer>().enabled = true;
            instance.objGrabbed.GetComponent<CircleCollider2D>().enabled = false;
            instance.trajectory.DrawTrajectory();
            instance.trajectory.Movements();
        }
        if (Input.GetKeyUp("z") && lanzando)
        {
            instance.GetComponent<LineRenderer>().enabled = false;
            instance.objGrabbed.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
            instance.objGrabbed.GetComponent<CircleCollider2D>().enabled = true;
<<<<<<< HEAD
<<<<<<< HEAD
            instance.objGrabbed.GetComponent<Rigidbody2D>().AddForce(instance.transform.GetChild(0).up * instance .trajectory._force); //Add Force to instantiated object. FixedDeltaTime will need to be equated either here via ForceMode or in Velocity. You choose.
            instance.objGrabbed.GetComponent<Ball>().enabled = true;
=======
            instance.objGrabbed.GetComponent<Ball>().lanzada = true;
            instance.objGrabbed.transform.parent = null;
            instance.objGrabbed.GetComponent<Rigidbody2D>().AddForce(instance.transform.GetChild(0).up * instance.trajectory._force); //Add Force to instantiated object. FixedDeltaTime will need to be equated either here via ForceMode or in Velocity. You choose.
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
            instance.objGrabbed.GetComponent<Ball>().lanzada = true;
            instance.objGrabbed.transform.parent = null;
            instance.objGrabbed.GetComponent<Rigidbody2D>().AddForce(instance.transform.GetChild(0).up * instance.trajectory._force); //Add Force to instantiated object. FixedDeltaTime will need to be equated either here via ForceMode or in Velocity. You choose.
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
            instance.objGrabbed = null;
            Debug.Log("Throwing");
            animator.SetTrigger("throwExit");
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db

        if (!instance.objGrabbed.GetComponent<Ball>().lanzada)
        {
            Debug.Log("A");
            instance.objGrabbed.transform.localPosition = new Vector3(0, 0, 0);
        }
<<<<<<< HEAD
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
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