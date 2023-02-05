using System;
using ProjectUtils.Attacking;
using UnityEngine;

namespace ProjectUtils.TopDown2D
{
    public abstract class Mover : Fighter
    {
        [Header("Movement")]
        [SerializeField] protected float speed = 4;
        [SerializeField] protected float airControl = 0.5f;
        [SerializeField] private LayerMask collisionLayer;
        private Vector3 _moveDelta;
        protected Rigidbody2D rb;
        private RaycastHit2D _hit;
        
        [Header("Attacking")]
        protected MeleeAttack meleeAttack;
        protected RangedAttack rangedAttack;
        
        protected Vector3 dashDirection;

        [Header("Jumping")]
        [SerializeField] protected float jumpForce;
        private float _coyoteTime;
        private float _jumpBufferTime;
        protected bool grounded;
        
        private BoxCollider2D _boxCollider;
        private float _climbingDirection;

        protected void Start()
        {
            if (TryGetComponent(out MeleeAttack meleeAttack)) this.meleeAttack = meleeAttack;
            if (TryGetComponent(out RangedAttack rangedAttack)) this.rangedAttack = rangedAttack;

            _boxCollider = gameObject.GetComponent<BoxCollider2D>();
            rb = GetComponent<Rigidbody2D>();
            _jumpBufferTime = float.MinValue;
        }

        protected void UpdateMotor(Vector3 input)
        {
            _moveDelta = new Vector3(input.x * speed, rb.velocity.y, 0);

            if (_moveDelta.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (_moveDelta.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            //Pushes mover if gets hit or dashes
            _moveDelta += pushDirection + dashDirection;
            //Lerps push and dash to 0
            pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, Time.fixedDeltaTime / 0.1f);
            dashDirection = Vector3.Lerp(dashDirection, Vector3.zero, Time.fixedDeltaTime / 0.075f);

            //Check if grounded
            if (Physics2D.BoxCast(transform.position, _boxCollider.size,0,Vector2.down, 0.1f, collisionLayer) )
            {
                grounded = true;
                if (rb.velocity.y <= 0) _coyoteTime = Time.time;
            }
            else
            {
                grounded = false;
            }

            //Check if colliding with wall
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(input.x, 0),
                Mathf.Abs(input.x * speed* Time.fixedDeltaTime), collisionLayer);
            if (hit == false)
            {
                Vector3 targetVelocity = grounded ? _moveDelta : Vector2.Lerp(rb.velocity, _moveDelta, Time.deltaTime * 20f * airControl);
                rb.velocity = (Vector2)targetVelocity;
                if (_climbingDirection != 0)
                {
                    _climbingDirection = 0;
                }
            }
            else
            {
                if (hit.transform.CompareTag("Climbable") && !grounded)
                {
                    _climbingDirection = _moveDelta.x;
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
                }
                else
                {
                    _climbingDirection = 0;
                }
            }

            //Check if JumpBuffer has input
            if(Time.time - _jumpBufferTime < 0.1f && grounded) Jump(jumpForce); 
        }

        protected void Dash(float dashForce, Vector3 direction)
        {
            if (direction != Vector3.zero) dashDirection = direction * dashForce;
            else
            {
                dashDirection = new Vector3(transform.localScale.x, 0, 0) * dashForce;
            }
        }

        protected void Jump(float force)
        {
            if (!grounded && Time.time - _coyoteTime > 0.15f && _climbingDirection == 0)
            {
                _jumpBufferTime = Time.time;
                return;
            }
            rb.velocity = new Vector2(_climbingDirection != 0 ? -_climbingDirection*force/4 : rb.velocity.x, force);
            _coyoteTime = float.MinValue;
        }



        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if(_boxCollider == null) return;
            Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y - 0.1f,0), _boxCollider.size );
        }
    }
}