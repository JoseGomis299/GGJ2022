using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField] private CheckPoint[] _checkPoints;

    private int currentCheckPointIndex;
    public static CheckPointController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        currentCheckPointIndex = 0;
        for (int i = 0; i < _checkPoints.Length; i++)
        {
            if (_checkPoints[i].reached && i > currentCheckPointIndex) currentCheckPointIndex = i;
        }

        if (currentCheckPointIndex == 2 && PlayerController.Instance.canDash == false)
            PlayerController.Instance.canDash = true;
        
        if (currentCheckPointIndex == 3 && PlayerController.Instance.canClimb == false)
            PlayerController.Instance.canClimb = true;
    }

    public Vector3 GetCheckPointPosition()
    {
        return _checkPoints[currentCheckPointIndex].transform.position;
    }
}
