using System;
using System.Collections;
using System.Collections.Generic;
using ProjectUtils.TopDown2D;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using Pathfinding;
using ProjectUtils.Attacking;
using UnityEngine.Serialization;

public class KoopaVoladorController : Mover
{
    private Vector3 movementDirection; //TRUE IZQUIERDA, FALSE DERECHA
    private Vector3 direction;

    //[FormerlySerializedAs("palodeciegodcha")] [SerializeField]
    //private GameObject palodeciego;
    // private BoxCollider2D palodeciegoCollider;
    //private bool aux;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject GFX;

    [SerializeField] private float searchingRadius;
    [SerializeField] private float attackingRadius;

    public bool objectiveFound = false;

    [SerializeField] float aispeed = 200f;
    float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;

    private Collider2D[] hitColliders;
    [SerializeField] private float distance;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        // palodeciego = transform.GetChild(0).gameObject;
        // palodeciegoCollider = palodeciego.GetComponent<BoxCollider2D>();

        direction = Vector3.one * Random.Range(-1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable actor = other.GetComponent<IDamageable>();
        if (actor == null)
        {
            movementDirection *= Random.Range(-1f, 0f);
        }
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
        if (distance <= searchingRadius)
        {
            movementDirection = (PlayerController.Instance.transform.position - transform.position).normalized;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (distance <= searchingRadius)
        {
            ApuntarEnemigo();
            rb.MovePosition(transform.position + transform.right);
            if (distance <= attackingRadius)
            {
                rangedAttack.Attack(transform.position,
                    movementDirection.normalized,
                    2, 0, 0, 0, 0, 2f);
            }
        }
    }
    void ApuntarEnemigo()
    {
        var dir = movementDirection.normalized;
        float angle = -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
    void OnDrawGizmos()
    {
            
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, searchingRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackingRadius);

    }
}
