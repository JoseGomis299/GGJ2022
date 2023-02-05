using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingScript : StateMachineBehaviour
{

    private PlayerActions instance;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
<<<<<<< Updated upstream
        instance =   animator.gameObject.GetComponent<PlayerActions>();
        
=======
    instance =   animator.gameObject.GetComponent<PlayerActions>();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
        lanzando = false;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        lanzando = false;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        lanzando = false;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        lanzando = false;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
>>>>>>> Stashed changes
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
<<<<<<< Updated upstream


        if (Input.GetKeyDown("q"))
=======
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
        

>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        

>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        

>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        

>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
        if (Input.GetKeyDown("z"))
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            Destroy(instance.objGrabbed);
=======
            instance.objGrabbed.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
            instance.objGrabbed.GetComponent<CircleCollider2D>().enabled = true;
<<<<<<< HEAD
<<<<<<< HEAD
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
>>>>>>> Stashed changes
            instance.objGrabbed = null;
            instance.trajectory.Shoot();
            //instance.objGrabbed.GetComponent<Rigidbody2D>().AddForce(instance.gameObject.GetComponent<PlayerActions>().GrabPoint.up * instance.trajectory._force); //Add Force to instantiated object. FixedDeltaTime will need to be equated either here via ForceMode or in Velocity. You choose.
            //Debug.Log("Throwing");
            animator.SetTrigger("throwExit");
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db

<<<<<<< Updated upstream
        //if (instance.objGrabbed == null || instance.objGrabbed.GetComponent<Ball>().lanzada) return;
        //instance.GrabPoint.transform.position = new Vector3(instance.GrabOffset.transform.position.x,
        //    instance.GrabOffset.transform.position.y, instance.GrabOffset.transform.position.z);
        //instance.objGrabbed.transform.localPosition = new Vector3(0,0,0);
=======
        if (!instance.objGrabbed.GetComponent<Ball>().lanzada)
        {
            Debug.Log("A");
            instance.objGrabbed.transform.localPosition = new Vector3(0, 0, 0);
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
>>>>>>> Stashed changes
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