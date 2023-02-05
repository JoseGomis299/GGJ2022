using ProjectUtils.TopDown2D;
using UnityEngine;
    public class PlayerController : Mover
    {
        private Vector3 _direction;
        private Vector3 _lastValidDirection;
        [Header("Cooldown")]
        [SerializeField] private float dashCoolDown;
        private float _lastDashTime;

        private void Awake()
        {
            _lastValidDirection = Vector3.right;
        }

        void Update()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            _direction = new Vector3(x, 0, 0);
            if (_direction != Vector3.zero) _lastValidDirection = _direction;


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
<<<<<<< HEAD
=======
                    meleeAttack.AttackCircle(_lastValidDirection, 2, 30);
>>>>>>> parent of 9c5231b (Merge branch 'main' into movimiento_personajes_Jonny_Trabuco)
                }
            }
        }

        private void FixedUpdate()
        {
            UpdateMotor(_direction);
        }
        
    }

