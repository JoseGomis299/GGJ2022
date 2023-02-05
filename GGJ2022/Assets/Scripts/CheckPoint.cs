using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool reached;

    private void Update()
    {
        if (!reached)
        {
            RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector2.down);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.up);

            if (hit1.collider != null && hit1.collider.CompareTag("Player"))
            {
                reached = true;
                return;
            }
            if (hit2.collider != null && hit1.collider.CompareTag("Player"))
            {
                reached = true;
                return;
            }
        }
    }
}
