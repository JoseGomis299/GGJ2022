using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingScript : StateMachineBehaviour
{
    private PlayerActions instance;
    private Trajectory trajectory;

    private CameraShake cameraShake;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        instance = animator.gameObject.GetComponent<PlayerActions>();
        trajectory = animator.gameObject.GetComponent<Trajectory>();

        instance.root.currentTime = instance.root.pullTime;
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        instance.source.clip = instance.clipShake;
        instance.source.volume = instance.volumeShake;
        instance.source.loop = true;
        instance.source.Play();


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKey("q"))
        {
            instance.root.currentTime -= Time.deltaTime;
            cameraShake.isShaking = true;

            if (instance.root.currentTime <= 0)
            {
                cameraShake.isShaking = false;
                instance.isPullingRoot = false;
                GameObject newRoot =  Instantiate(instance.root.rootObj, instance.GrabPoint);
                newRoot.GetComponent<Ball>().lanzada = false;
                instance.objGrabbed = newRoot;
                trajectory.sphere = instance.root.rootObj;
                newRoot.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                //Destroy(instance.root.gameObject);
                instance.lanzandoBola = false;
                animator.Play("GrabbingObj");
            }
            
        }
        else
        {
            cameraShake.isShaking = false;
            instance.isPullingRoot = false;
            animator.Play("Iddle");
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        instance.source.Stop();
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
