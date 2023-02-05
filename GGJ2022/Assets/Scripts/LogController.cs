using System.Collections;
using System.Collections.Generic;
using ProjectUtils.Attacking;
using UnityEngine;

public class LogController : MonoBehaviour, IDamageable
{
    public void ReceiveDamage(Damage dmg)
    {
        if (transform.localRotation.z > 0)
        {
            if(transform.localRotation.z - dmg.damageAmount < 0) transform.localRotation = Quaternion.Euler(Vector3.zero);
            else transform.Rotate(Vector3.forward * (-dmg.damageAmount * 3));
        }
    }
}
