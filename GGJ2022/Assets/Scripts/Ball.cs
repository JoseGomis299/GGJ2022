using ProjectUtils.Attacking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField]
    private float dmg;
<<<<<<< HEAD
<<<<<<< HEAD
=======
    public bool lanzada;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
    public bool lanzada;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
<<<<<<< HEAD
<<<<<<< HEAD
        if(collision.transform.tag == "Ground")
=======

        Debug.Log(collision.transform.CompareTag("Ground"));
        if(collision.transform.tag == "Ground" && lanzada)
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======

        Debug.Log(collision.transform.CompareTag("Ground"));
        if(collision.transform.tag == "Ground" && lanzada)
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
        {
            Destroy(gameObject, 0.5f);
        }
        
            IDamageable rival = collision.gameObject.GetComponent<IDamageable>();
<<<<<<< HEAD
<<<<<<< HEAD
        if (rival != null)
        {
            rival.ReceiveDamage(new Damage(transform.position, dmg, 0));
=======
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
        if (rival != null && lanzada)
        {
            rival.ReceiveDamage(new Damage(transform.position, dmg, 0));
            Destroy(gameObject);
<<<<<<< HEAD
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
        }

    }
}
