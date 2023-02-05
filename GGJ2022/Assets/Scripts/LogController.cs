using System.Collections;
using System.Collections.Generic;
using ProjectUtils.Attacking;
using UnityEngine;

public class LogController : MonoBehaviour, IDamageable
{
    public AudioSource source;
    public AudioClip clip;
    public float volume = 0.3f;
    public bool loop = false;

    public void ReceiveDamage(Damage dmg)
    {
        source.clip = clip;
        source.volume = volume;
        source.loop = loop;
        source.Play();
        if (transform.localRotation.z > 0)
        {
            if(transform.localRotation.z - dmg.damageAmount < 0) transform.localRotation = Quaternion.Euler(Vector3.zero);
            else transform.Rotate(Vector3.forward * (-dmg.damageAmount * 3));
        }
    }
}
