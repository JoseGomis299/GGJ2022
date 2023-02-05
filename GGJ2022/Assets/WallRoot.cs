using System;
using System.Collections;
using System.Collections.Generic;
using ProjectUtils.Attacking;
using UnityEngine;

public class WallRoot : MonoBehaviour, IDamageable
{
    [SerializeField] private Vector3 growDirection;

    [SerializeField] private Vector3 lastPosition;

    private void Start()
    {
        var child = transform.GetChild(0);
        lastPosition = child.transform.position + child.transform.localScale.x*growDirection;
        StartCoroutine(GrowRoot(transform.GetChild(0)));
    }

    public void ReceiveDamage(Damage dmg)
    {
        if (dmg.damageAmount == -1)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            var child = transform.GetChild(0);
            lastPosition = child.transform.position + (child.transform.localScale.x/2)*growDirection;
            StartCoroutine(GrowRoot(child));
        }
    }

    private IEnumerator GrowRoot(Transform root)
    {
        while (root.position != lastPosition)
        {
            root.position = Vector3.Lerp(root.position, lastPosition, Time.deltaTime);
            yield return null;
        }
    }
}
