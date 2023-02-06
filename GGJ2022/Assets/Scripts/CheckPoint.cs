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
            RaycastHit2D down = Physics2D.Raycast(transform.position, Vector2.down);
            RaycastHit2D up = Physics2D.Raycast(transform.position, Vector2.up);

            if (down.collider != null && down.collider.CompareTag("Player"))
            {
                reached = true;
                Debug.Log(transform.name);
            }
            if (up.collider != null && up.collider.CompareTag("Player"))
            {
                reached = true;
                Debug.Log(transform.name);
            }
        }
    }
}
