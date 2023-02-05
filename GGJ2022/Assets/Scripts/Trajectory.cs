using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CANNON TRAJECTORY PROJECTION METHOD

//Position(At Specified Time) = Initial Positions of X and Y multiplied by Speed, then subtract Gravity Factor from Y
//f(t) = (x0 + x*t, y0 + y*t - 9.81t²/2)
//In essence, move X and Y at a constant speed, subtract Gravity from Y

//Variables to decide:
//Force, Mass, Origin & Direction in which to launch objects
//Simulation Length, Step Measurement Interval
//Variables to calculate: 
//Max Steps, Velocity, and Position at each Step :)

//Currently does not account for 3-D, Drag, Gravity Scale, Bounces, or Ground Velocity

public class Trajectory : MonoBehaviour
{
    private LineRenderer _lr; //Line to predict trajectory

    [SerializeField]
    private GameObject _sphere = null; //Bullets, for all intents and purposes
    private Rigidbody2D _sphereRB = null; //Rigidbodies of bullets, to add force
    [SerializeField] LayerMask excludeLayer;
    public float _force = 500; //Force, can be assigned in Unity Inspector
    private float _mass; //Automatic mass of an object is 1, can be reassigned
    private float _fixedDeltaTime;
    private float _vel; //Initial Velocity, calculated via V = Force / Mass * fixedTime (0.02)
    private float _gravity;
    private float _collisionCheckRadius = 0.1f; //Collision radius of last point on SimulationArc, to communicate with it when to stop. Currently using IgnoreRaycast Layer on some objects, suboptimal
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
    public LayerMask ignoreLayer;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
    public LayerMask ignoreLayer;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
    public LayerMask ignoreLayer;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
    public LayerMask ignoreLayer;
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
>>>>>>> Stashed changes

    private PlayerActions playerActions;

    void Start()
    {
        playerActions = GetComponent<PlayerActions>();

        _lr = GetComponent<LineRenderer>();
        _lr.startColor = Color.white;

        _sphereRB = _sphere.GetComponent<Rigidbody2D>();
        _mass = _sphereRB.mass;
    }

    void Update()
    {
        playerActions.GrabPoint.position = playerActions.GrabOffset.position;
    }

    public void Shoot()
    {
        GameObject sphere = Instantiate(_sphere, transform.position + transform.up, Quaternion.identity); //Offset spawn position to come out of the end of the cannon
        Rigidbody2D sphereRB = sphere.GetComponent<Rigidbody2D>();
        sphereRB.AddForce(playerActions.GrabPoint.up * _force); //Add Force to instantiated object. FixedDeltaTime will need to be equated either here via ForceMode or in Velocity. You choose.
    }

    public void DrawTrajectory()
    {
        _lr.positionCount = SimulateArc().Count;
        for (int a = 0; a < _lr.positionCount; a++)
        {
            _lr.SetPosition(a, SimulateArc()[a]); //Add each Calculated Step to a LineRenderer to display a Trajectory. Look inside LineRenderer in Unity to see exact points and amount of them
        }
    }

    private List<Vector2> SimulateArc() //A method happening via this List
    {
        List<Vector2> lineRendererPoints = new List<Vector2>(); //Reset LineRenderer List for new calculation

        float maxDuration = 5f; //INPUT amount of total time for simulation
        float timeStepInterval = 0.1f; //INPUT amount of time between each position check
        int maxSteps = (int)(maxDuration / timeStepInterval);//Calculates amount of steps simulation will iterate for
        Vector2 directionVector = playerActions.GrabPoint.up; //INPUT launch direction (This Vector2 is automatically normalized for us, keeping it in low and communicable terms)
        Vector2 launchPosition = playerActions.GrabPoint.position + playerActions.GrabPoint.up; //INPUT launch origin (Important to make sure RayCast is ignoring some layers (easiest to use default Layer 2))

        _vel = _force / _mass * Time.fixedDeltaTime; //Initial Velocity, or Velocity Modifier, with which to calculate Vector Velocity

        for (int i = 0; i < maxSteps; ++i)
        {
            //Remember f(t) = (x0 + x*t, y0 + y*t - 9.81t²/2)
            //calculatedPosition = Origin + (transform.up * (speed * which step * the length of a step);
            Vector2 calculatedPosition = launchPosition + directionVector * _vel * i * timeStepInterval; //Move both X and Y at a constant speed per Interval
            calculatedPosition.y += Physics2D.gravity.y / 2 * Mathf.Pow(i * timeStepInterval, 2); //Subtract Gravity from Y

            lineRendererPoints.Add(calculatedPosition); //Add this to the next entry on the list

            if (CheckForCollision(calculatedPosition)) //if you hit something, stop adding positions
            {
                break; //stop adding positions
            }
        }
        return lineRendererPoints;
    }

    private bool CheckForCollision(Vector2 position)
    {
<<<<<<< Updated upstream
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, _collisionCheckRadius,~excludeLayer); //Measure collision via a small circle at the latest position, dont continue simulating Arc if hit
=======
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, _collisionCheckRadius); //Measure collision via a small circle at the latest position, dont continue simulating Arc if hit
=======
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, _collisionCheckRadius,~ignoreLayer); //Measure collision via a small circle at the latest position, dont continue simulating Arc if hit
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, _collisionCheckRadius,~ignoreLayer); //Measure collision via a small circle at the latest position, dont continue simulating Arc if hit
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, _collisionCheckRadius,~ignoreLayer); //Measure collision via a small circle at the latest position, dont continue simulating Arc if hit
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, _collisionCheckRadius,~ignoreLayer); //Measure collision via a small circle at the latest position, dont continue simulating Arc if hit
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
>>>>>>> Stashed changes
        if (hits.Length > 0) //Return true if something is hit, stopping Arc simulation
        {
            return true;
        }
        return false;
    }

    public void Movements() //WASD move + QE rotate method
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
<<<<<<< Updated upstream
            playerActions.GrabPoint.Rotate(0, 0, 0.5f);
=======
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            transform.GetChild(0).Rotate(0, 0, -100f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.GetChild(0).Rotate(0, 0, 100f * Time.deltaTime);
=======
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
            transform.GetChild(0).Rotate(0, 0, -100f * gameObject.transform.localScale.x  * Time.deltaTime);
>>>>>>> Stashed changes
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
<<<<<<< Updated upstream
            playerActions.GrabPoint.Rotate(0, 0, -0.5f);
=======
            transform.GetChild(0).Rotate(0, 0, 100f * gameObject.transform.localScale.x * Time.deltaTime);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
>>>>>>> Stashed changes
        }
    }
}
