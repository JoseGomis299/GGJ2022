using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool startDirection; //TRUE IZQUIERDA, FALSE DERECHA
    private int direction;

    [SerializeField] private int speed = 2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startDirection = (Random.value > 0.5f);
        if (startDirection)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(1 * speed * direction, rb.velocity.y);
    }

    public void setSpeed(int input)
    {
        speed = input;
    }

    public int getSpeed()
    {
        return speed;
    }
}
