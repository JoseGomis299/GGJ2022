using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private void Update()
    {
        transform.position = PlayerController.Instance.transform.position;
    }
}
