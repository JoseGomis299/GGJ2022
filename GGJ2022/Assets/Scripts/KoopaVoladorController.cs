using System;
using System.Collections;
using System.Collections.Generic;
using ProjectUtils.TopDown2D;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using Pathfinding;
using UnityEngine.Serialization;

public class KoopaVoladorController : Mover
{
    private bool startDirection; //TRUE IZQUIERDA, FALSE DERECHA
    private Vector3 direction;
    
    [FormerlySerializedAs("palodeciegodcha")] [SerializeField]
    private GameObject palodeciego;
    private BoxCollider2D palodeciegoCollider;
    private bool aux;
    [SerializeField]
    private GameObject projectile;
    [SerializeField] private GameObject GFX;

    
    public Transform target;
    public bool objectiveFound = false;

    [SerializeField]
    float aispeed = 200f;
    float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;

    private Collider2D[] hitColliders;
    [SerializeField]
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        palodeciego = transform.GetChild(0).gameObject;
        palodeciegoCollider = palodeciego.GetComponent<BoxCollider2D>();



        startDirection = (Random.value > 0.5f);
        if (startDirection)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }



        Debug.Log(rb==null);
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0f , 0.5f);
        
    }

    void UpdatePath()
    {
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Ground") ||other.gameObject.tag.Equals("wall") ||other.gameObject.tag.Equals("Climbable") || other.gameObject.tag.Equals("palote"))
        {
            Debug.Log("Ahh **Gime**");
            direction *= -1;
        }

    }
    
    
    

    // Update is called once per frame
    void FixedUpdate()
    {

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count) {
            reachedEndOfPath = true; } else { reachedEndOfPath = false;}

        Vector2 aidirection = Vector2.zero;
        
        if (currentWaypoint >= 0 && currentWaypoint < path.vectorPath.Count)
        {
             aidirection = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        }
        
        //Debug.Log("aidirection = " + aidirection);
        Vector2 force = aidirection * aispeed * Time.deltaTime;
        //Debug.Log("aiforce = " + force);
        
        if (objectiveFound)
        {
            distance = Vector3.Distance (transform.position, target.position);

            if (distance <= 3)
            {
                ApuntarEnemigo();
                rb.velocity = rb.velocity/3;
                rangedAttack.Attack(transform.position, 
                        target.position - transform.position, 
                        2, 0, 0, 0, 0, 2f, Vector3.one*0.25f);

                //DISPARAR
            }
            else
            {
                if (distance > 3 && distance <= 5)
                {
                    ApuntarEnemigo();

                    rb.AddForce(force);

                    float iaDistance = 0;
                    if (currentWaypoint >= 0 && currentWaypoint < path.vectorPath.Count)
                        iaDistance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

                    if (iaDistance < nextWaypointDistance)
                    {
                        currentWaypoint++;
                    }
                }
                else
                {
                    objectiveFound = false;
                    
                }
                
            }
        }
        else
        {
            UpdateMotor(direction);
            
            GFX.transform.localRotation = Quaternion.Euler(0,0,1);
            
            hitColliders = Physics2D.OverlapCircleAll(transform.position, 5f);
        
            foreach (Collider2D hitCollider in hitColliders)
            {
              //z Debug.Log("mE cOrrRRRooooo");
                
                if (hitCollider.gameObject.CompareTag("Player"))
                {
                    objectiveFound = true;
                }
            }
            
            
        }

        



    }

    void ApuntarEnemigo()
    {
        if (direction == Vector3.right)
        {
            float angle = Mathf.Atan2((target.transform.position - transform.position).x, (target.transform.position - transform.position).y) * Mathf.Rad2Deg;
            GFX.transform.localRotation = Quaternion.Euler(0,0,angle);

        }
        else
        {
            float angle = -Mathf.Atan2((target.transform.position - transform.position).x, (target.transform.position - transform.position).y) * Mathf.Rad2Deg;
            GFX.transform.localRotation = Quaternion.Euler(0,0,angle);

        }
    }
    
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 5f);
        
    }
}
