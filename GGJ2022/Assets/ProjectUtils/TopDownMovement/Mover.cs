using System;
using System.Collections;
using ProjectUtils.Attacking;
using ProjectUtils.ObjectPooling;
using UnityEngine;

namespace ProjectUtils.TopDown2D
{
    public abstract class Mover : Fighter
    {
        [Header("Movement")]
        [SerializeField] protected float speed = 4;
        [SerializeField] protected float airControl = 0.5f;
        [SerializeField] private LayerMask collisionLayer;
        public bool canClimb;
        public bool canDash;
        [SerializeField] private GameObject dashEcho;
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
<<<<<<< Updated upstream
        public bool grounded;
=======
        [SerializeField]protected bool grounded;
>>>>>>> Stashed changes
        
        private CapsuleCollider2D _capsuleCollider;
        protected float climbingDirection;

        protected void Start()
        {
            if (TryGetComponent(out MeleeAttack meleeAttack)) this.meleeAttack = meleeAttack;
            if (TryGetComponent(out RangedAttack rangedAttack)) this.rangedAttack = rangedAttack;

<<<<<<< Updated upstream
            _capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
            _rb = GetComponent<Rigidbody2D>();
=======
            _boxCollider = gameObject.GetComponent<BoxCollider2D>();
            rb = GetComponent<Rigidbody2D>();
>>>>>>> Stashed changes
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
            if (Physics2D.CapsuleCast(new Vector2(transform.position.x,transform.position.y+_capsuleCollider.offset.y), _capsuleCollider.size,_capsuleCollider.direction,0, Vector2.down, 0.1f, collisionLayer) )
            {
                grounded = true;
                if (rb.velocity.y <= 0) _coyoteTime = Time.time;
            }
            else
            {
                grounded = false;
            }

            //Check if colliding with wall
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right*input.x,  Mathf.Abs(transform.localScale.x/2)+0.1f, collisionLayer);
            if (hit.collider == null)
            {
<<<<<<< Updated upstream
                Vector3 targetVelocity = grounded ? _moveDelta : Vector2.Lerp(_rb.velocity, _moveDelta, Time.deltaTime * 20f * airControl);
                _rb.velocity = (Vector2)targetVelocity;
                if (climbingDirection != 0)
=======
                Vector3 targetVelocity = grounded ? _moveDelta : Vector2.Lerp(rb.velocity, _moveDelta, Time.deltaTime * 20f * airControl);
                rb.velocity = (Vector2)targetVelocity;
                if (_climbingDirection != 0)
>>>>>>> Stashed changes
                {
                    climbingDirection = 0;
                }
            }
            else
            {
                if (hit.transform.CompareTag("Climbable") && !grounded && canClimb)
                {
<<<<<<< Updated upstream
                    climbingDirection = input.x;
                    _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.8f);
=======
                    _climbingDirection = _moveDelta.x;
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
>>>>>>> Stashed changes
                }
                else
                {
                    climbingDirection = 0;
                }
            }

            //Check if JumpBuffer has input
            if(Time.time - _jumpBufferTime < 0.1f && grounded) Jump(jumpForce); 
        }

        protected void Dash(float dashForce, Vector3 direction)
        {
            if(!canDash) return;
            if (direction != Vector3.zero) dashDirection = direction * dashForce;
            else
            {
                dashDirection = new Vector3(transform.localScale.x, 0, 0) * dashForce;
            }

            if (dashEcho != null) StartCoroutine(dashDisplay());
        }

        private IEnumerator dashDisplay()
        {
            while (Mathf.Abs(dashDirection.x) > 1f)
            {
                ObjectPool.Instance.InstantiateFromPool(dashEcho, transform.position, Quaternion.identity, true);
                yield return new WaitForSeconds(0.01f);
            }
        }

        protected void Jump(float force)
        {
            if (!grounded && Time.time - _coyoteTime > 0.15f && climbingDirection == 0)
            {
                _jumpBufferTime = Time.time;
                return;
            }
<<<<<<< Updated upstream
            _rb.velocity = new Vector2(climbingDirection != 0 ? -climbingDirection*force : _rb.velocity.x, force);
=======
            rb.velocity = new Vector2(_climbingDirection != 0 ? -_climbingDirection*force/4 : rb.velocity.x, force);
>>>>>>> Stashed changes
            _coyoteTime = float.MinValue;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if(_capsuleCollider == null) return;
            Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y - 0.1f,0), _capsuleCollider.size );
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(new Vector3(transform.position.x+0.2f*transform.localScale.x, transform.position.y, 0), _capsuleCollider.size.x/2);
        }
    }
}