using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topomov : MonoBehaviour
{

    private Rigidbody2D rb;
    public float jump = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float diX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(7f * diX, rb.velocity.y);

        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
}
