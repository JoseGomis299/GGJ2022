using ProjectUtils.Attacking;
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

        public static PlayerController Instance;
        private void Awake()
        {
            if (Instance == null) Instance = this;
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
               if(animator != null) animator.SetBool("onWalking", true);
                _lastValidDirection = _direction;
            }
            else if(animator != null) animator.SetBool("onWalking", false);



            if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time - _lastDashTime >= dashCoolDown)
            {
                _lastDashTime = Time.time;
                Dash(35f, _direction);
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
                }
            }

            if(playerActions == null) return;
            if (playerActions.isPullingRoot || isReallyAtacking)
            {
                Debug.Log("VAR");
                _direction = new Vector3(0, 0, 0);
            }
        }
        private void FixedUpdate()
        {
            UpdateMotor(_direction);
        }

        protected override void Death()
        {
            transform.position = CheckPointController.Instance.GetCheckPointPosition();
        }
    }

