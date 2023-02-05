using System;
using System.Collections;
using System.Collections.Generic;
using ProjectUtils.Attacking;
using UnityEngine;

public class WallRoot : MonoBehaviour, IDamageable
{
    [SerializeField] private Vector3 growDirection;

    private Vector3 _lastPosition;
    public AudioSource source;
    public AudioClip clip;
    public float volume = 0.3f;
    public bool loop = false;
    
    public void ReceiveDamage(Damage dmg)
    {
        if (dmg.damageAmount == -1)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            var child = transform.GetChild(0);
            _lastPosition = (child.transform.localScale.x)*growDirection;
            StartCoroutine(GrowRoot(child));
        }
    }

    private IEnumerator GrowRoot(Transform root)
    {
        source.clip = clip;
        source.volume = volume;
        source.loop = loop;
        source.Play();
        while (root.position != _lastPosition)
        {
            root.localPosition = Vector3.Lerp(root.localPosition, _lastPosition, Time.deltaTime);
            yield return null;
        }
        source.Stop();
    }
}
