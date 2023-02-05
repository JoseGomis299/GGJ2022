using System;
using ProjectUtils.Attacking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float dmg;
    public bool lanzada = false;

    public AudioSource source;
    public AudioClip clip;
    public float volume = 0.3f;
    public bool loop = false;

    private void Start()
    {
        source = GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("A");
        if (!lanzada) return;
        Debug.Log("B");

        source.clip = clip;
        source.volume = 1;
        source.loop = loop;
        source.Play();
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
        Debug.Log("A");

        if (!lanzada) return;
        Debug.Log("B");

        source.clip = clip;
        source.volume = 1;
        source.loop = loop;
        source.Play();
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