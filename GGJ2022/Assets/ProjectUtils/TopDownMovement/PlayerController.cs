using ProjectUtils.ObjectPooling;
using ProjectUtils.TopDown2D;
using UnityEngine;
    public class PlayerController : Mover
    {
        private Vector3 _direction;
        private Vector3 _lastValidDirection;
        [Header("Cooldown")]
        [SerializeField] private float dashCoolDown;
        private float _lastDashTime;
    public bool isReallyAtacking;
        private Animator animator;
    private PlayerActions playerActions;
        private void Awake()
        {
            _lastValidDirection = Vector3.right;
            animator = GetComponent<Animator>();
            playerActions = gameObject.GetComponent<PlayerActions>();
        }

    public void Update()
    {
            float x = Input.GetAxisRaw("Horizontal");
            _direction = new Vector3(x, 0, 0);

            if (_direction != Vector3.zero)
            {
                gameObject.GetComponent<Animator>().SetBool("onWalking", true);
                _lastValidDirection = _direction;
            }
            else
                gameObject.GetComponent<Animator>().SetBool("onWalking", false);



            if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time - _lastDashTime >= dashCoolDown)
            {
                _lastDashTime = Time.time;
                Dash(25f, _direction);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump(jumpForce);
            }

            if (Input.GetMouseButtonDown(0))
            {

            }

            if (Input.GetMouseButtonDown(1))
            {
                if (meleeAttack != null)
                {
                    meleeAttack.AttackCircle(_lastValidDirection, 30, 30, gameObject.GetInstanceID());
                }
            }

        if (playerActions.isPullingRoot || isReallyAtacking)
        {
            _direction = new Vector3(0, 0, 0);
        }

    }
        private void FixedUpdate()
        {
            UpdateMotor(_direction);
        }
        
    }

