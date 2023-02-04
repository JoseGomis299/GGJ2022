using ProjectUtils.Attacking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField]
    private float dmg;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            Destroy(gameObject, 0.5f);
        }
        
            IDamageable rival = collision.gameObject.GetComponent<IDamageable>();
        if (rival != null)
        {
            rival.ReceiveDamage(new Damage(transform.position, dmg, 0));
        }

    }
}
