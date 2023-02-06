using System.Collections;
using System.Collections.Generic;
using ProjectUtils.Attacking;
using UnityEngine;
public class LogController : MonoBehaviour, IDamageable
{
    public AudioSource source;
    public AudioClip clip;
    public float volume = 0.3f;
    public float direction;
    public bool loop = false;

    public void ReceiveDamage(Damage dmg)
    {
        if (transform.localRotation.eulerAngles.z is <= 0 or >= 180) return;
        Debug.Log(transform.localRotation.eulerAngles.z);
        source.clip = clip;
        source.volume = volume;
        source.loop = loop;
        source.Play();
        transform.Rotate(Vector3.forward * (direction*dmg.damageAmount * 4.5f));
    }
}