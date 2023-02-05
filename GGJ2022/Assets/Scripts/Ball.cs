using System;
using ProjectUtils.Attacking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float dmg;
    public bool lanzada;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!lanzada) return;

        IDamageable rival = collision.gameObject.GetComponent<IDamageable>();
        if (rival != null)
        {
            rival.ReceiveDamage(new Damage(transform.position, dmg, 0));
            Destroy(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!lanzada) return;

        IDamageable rival = col.gameObject.GetComponent<IDamageable>();
        if (rival != null)
        {
            rival.ReceiveDamage(new Damage(transform.position, dmg, 0));
            Destroy(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}