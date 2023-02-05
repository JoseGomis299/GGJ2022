using System;
using System.Collections;
using System.Collections.Generic;
using ProjectUtils.Attacking;
using UnityEngine;

public class WallRoot : MonoBehaviour, IDamageable
{
    [SerializeField] private Vector3 growDirection;

    private Vector3 _lastPosition;
    
    public void ReceiveDamage(Damage dmg)
    {
        if (dmg.damageAmount == -1)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            var child = transform.GetChild(0);
            _lastPosition = child.transform.position + (child.transform.localScale.x)*growDirection;
            StartCoroutine(GrowRoot(child));
        }
    }

    private IEnumerator GrowRoot(Transform root)
    {
        while (root.position != _lastPosition)
        {
            root.position = Vector3.Lerp(root.position, _lastPosition, Time.deltaTime);
            yield return null;
        }
    }
}
