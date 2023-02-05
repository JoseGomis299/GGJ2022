using System;
using System.Collections;
using System.Collections.Generic;
using ProjectUtils.TopDown2D;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class KoopaVoladorController : Mover
{
    private bool startDirection; //TRUE IZQUIERDA, FALSE DERECHA
    private Vector3 direction;
    
    [SerializeField]
    private GameObject palodeciegodcha;
    private BoxCollider2D palodeciegodchaCollider;
    [SerializeField]
    private GameObject palodeciegoizq;
    private BoxCollider2D palodeciegodizqCollider;
    private bool aux;


    // Start is called before the first frame update
    void Awake()
    {
        palodeciegodcha = transform.GetChild(0).gameObject;
        palodeciegodchaCollider = palodeciegodcha.GetComponent<BoxCollider2D>();
        palodeciegoizq = transform.GetChild(1).gameObject;
        palodeciegodizqCollider = palodeciegoizq.GetComponent<BoxCollider2D>();



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
    
    
    

    // Update is called once per frame
    void FixedUpdate()
    {

        
        UpdateMotor(direction);
       
    }
}
