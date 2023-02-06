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
    
    private bool aux;

    // Start is called before the first frame update
    void Awake()
    {
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
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            IDamageable pc = col.GetComponent<IDamageable>();
            if (pc != null && col.CompareTag("Player"))
            {
                pc.ReceiveDamage(new Damage(transform.position, 2, 20f));
            }
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit2D down = Physics2D.Raycast(new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y), Vector2.down, capsuleCollider.size.y/2 + 0.3f);
        RaycastHit2D right = Physics2D.Raycast(transform.position, Vector2.right*transform.localScale.x, capsuleCollider.size.x/2 + 0.1f);

        if (!down)
        {
            direction *= -1;

        }
        
        if(right && !right.collider.CompareTag("Player"))
        {
            direction *= -1;
        }
        

        UpdateMotor(direction);
    }

    private void OnDrawGizmos()
    {
        if(capsuleCollider == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + ((capsuleCollider.size.x/2) + 0.1f)*transform.localScale.x, transform.position.y));
        Gizmos.DrawLine(new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y), new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y - (capsuleCollider.size.y/2+0.3f)));
    }
}
