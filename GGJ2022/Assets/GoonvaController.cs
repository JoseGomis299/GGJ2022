using System;
using System.Collections;
using System.Collections.Generic;
using ProjectUtils.Attacking;
using ProjectUtils.TopDown2D;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class GoonvaController : Mover
{
    private bool startDirection; //TRUE IZQUIERDA, FALSE DERECHA
    private Vector3 direction;
    
    [SerializeField]
    private GameObject palodeciego;
    private BoxCollider2D palodeciegoCollider;


    private bool aux;


    // Start is called before the first frame update
    void Awake()
    {
        palodeciego = transform.GetChild(0).gameObject;
        palodeciegoCollider = palodeciego.GetComponent<BoxCollider2D>();



        startDirection = (Random.value > 0.5f);
        if (startDirection)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("Nene que te caes");
            direction *= -1;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Nena tiene el pelo enfarrangao, aparta.");
            IDamageable pc = col.GetComponent<IDamageable>();
            if (pc != null && col.CompareTag("Player"))
            {
                pc.ReceiveDamage(new Damage(transform.position, 2, 10));
            }
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

         UpdateMotor(direction);
       
    }
}
