using ProjectUtils.Attacking;
using ProjectUtils.ObjectPooling;
using ProjectUtils.TopDown2D;
using UnityEngine;
using UnityEngine.UI;

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
        public bool recover = true;

        [SerializeField] private HealthBar healthBar;
        
        private void Awake()
        {
           if(healthBar != null) healthBar.SetMaxHealth(maxHealth/maxHealth);

            if (Instance == null) Instance = this;
            _lastValidDirection = Vector3.right;
            animator = GetComponent<Animator>();
            playerActions = gameObject.GetComponent<PlayerActions>();
        }

        public void Update()
        {

            healthBar.SetHealth(health/maxHealth);
            
            if (grounded  && recover)
            {
                animator.SetBool("isJumping", false);
                recover = false;
            }

            float x = Input.GetAxisRaw("Horizontal");
            _direction = new Vector3(x, 0, 0);

            if (_direction != Vector3.zero)
            {
               if(animator != null) animator.SetBool("onWalking", true);
                _lastValidDirection = _direction;
            }
            else if(animator != null) animator.SetBool("onWalking", false);



            if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time - _lastDashTime >= dashCoolDown && canDash)
            {
            PlayerActions playerActions = GetComponent<PlayerActions>();
            playerActions.source.clip = playerActions.clipDash;
            playerActions.source.loop = false;
            playerActions.source.volume = playerActions.volumeDash;
            playerActions.source.Play();
                _lastDashTime = Time.time;
                Dash(35f, _direction);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump(jumpForce);
            }

            if(playerActions == null) return;
            if (playerActions.isPullingRoot || isReallyAtacking)
            {
                Debug.Log("VAR");
                _direction = new Vector3(0, 0, 0);
            }

        if (
          climbingDirection != 0)
        {
            GetComponent<Animator>().SetBool("isWallJumping",true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWallJumping", false);

        }
    }
        private void FixedUpdate()
        {
            UpdateMotor(_direction);

        }
        
        protected override void Death()
        {
            animator.Play("Dead");
        }

        
    }

