using System.Collections;
using System.Collections.Generic;
using ProjectUtils.Attacking;
using UnityEngine;

public class LogController : MonoBehaviour, IDamageable
{
    public void ReceiveDamage(Damage dmg)
    {
        if(transform.localRotation.z > 0) transform.Rotate(Vector3.forward*-dmg.damageAmount);
    }
}
