using ProjectUtils.Attacking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField]
    private float dmg;
    public bool lanzada;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground" && lanzada)
        {
            Destroy(gameObject, 0.5f);
        }
        
            IDamageable rival = collision.gameObject.GetComponent<IDamageable>();
        if (rival != null && lanzada)
        {
            rival.ReceiveDamage(new Damage(transform.position, dmg, 0));
            Destroy(gameObject);
        }

    }
}
