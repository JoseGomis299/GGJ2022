using System;
using ProjectUtils.Attacking;
using UnityEngine;

namespace ProjectUtils.TopDown2D
{
    public abstract class Mover : Fighter
    {
        private Vector3 _moveDelta;
        [SerializeField] protected float speed = 4;
        [SerializeField] private LayerMask collisionLayer;
        [SerializeField] private GameObject moverDisplay;
        private Rigidbody2D rb;
        private RaycastHit2D _hit;
        protected MeleeAttack meleeAttack;
        protected RangedAttack rangedAttack;
        
        protected Vector3 dashDirection;

        [SerializeField]protected float jumpForce;
       private float coyoteTime;
        private float jumpBufferTime;

        [SerializeField]  private bool grounded;

        private BoxCollider2D _boxCollider;

        protected virtual void Start()
        {
            if (TryGetComponent(out MeleeAttack meleeAttack)) this.meleeAttack = meleeAttack;
            if (TryGetComponent(out RangedAttack rangedAttack)) this.rangedAttack = rangedAttack;

            _boxCollider = gameObject.GetComponent<BoxCollider2D>();
            rb = GetComponent<Rigidbody2D>();
            jumpBufferTime = float.MinValue;
        }

        protected virtual void UpdateMotor(Vector3 input)
        {
            _moveDelta = new Vector3(input.x * speed, rb.velocity.y, 0);

            if (_moveDelta.x < 0)
            {
                moverDisplay.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (_moveDelta.x > 0)
            {
                moverDisplay.transform.localScale = new Vector3(1, 1, 1);
            }

            //Pushes mover if gets hit or dashes
            _moveDelta += pushDirection;
            _moveDelta += dashDirection;
            //Lerps push and dash to 0
            pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);
            dashDirection = Vector3.Lerp(dashDirection, Vector3.zero, Time.fixedDeltaTime / 0.075f);

            if (Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y / 2 + 0.1f, collisionLayer) )
            {
                grounded = true;
                if (rb.velocity.y <= 0) coyoteTime = Time.time;
            }
            else
            {
                grounded = false;
            }
            
            if (!Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0),
                    Mathf.Abs(_moveDelta.x * Time.fixedDeltaTime), collisionLayer))
                rb.velocity = _moveDelta;

            if(Time.time - jumpBufferTime < 0.1f && grounded) Jump(jumpForce);
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
            if (!grounded && Time.time - coyoteTime > 0.15f)
            {
                jumpBufferTime = Time.time;
                return;
            }
            rb.velocity = new Vector2(rb.velocity.x, force);
            coyoteTime = float.MinValue;
        }



        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position+new Vector3(0, -transform.localScale.y/2 - 0.1f,0));
        }
    }
}