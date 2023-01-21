using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    bool IsMoving {
        set {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    public float moveSpeed = 700f;
    public float maxSpeed = 2.2f;
    public float idleFriction = 0.9f;
    public float collisionOffset = 0.85f;
    public ContactFilter2D movementFilter;
    public AttackHitbox attack; 

    Vector2 movementInput = Vector2.zero;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;

    [SerializeField] private AudioSource SwordAttackEffect;

    bool isMoving = false;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate() {
        if(canMove == true && movementInput != Vector2.zero) {
            // rb.velocity = Vector2.ClampMagnitude(rb.velocity + (movementInput * moveSpeed * Time.deltaTime), maxSpeed);
            rb.AddForce(movementInput * moveSpeed * Time.deltaTime); 

            if (rb.velocity.magnitude > maxSpeed) {

                float limitSpeed = Mathf.Lerp(rb.velocity.magnitude, maxSpeed, idleFriction);
                rb.velocity = rb.velocity.normalized * limitSpeed;

            }

            if (movementInput.x < 0){
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("isFacingRight", false);
            } else if (movementInput.x > 0){
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("isFacingRight", true);
            }

            IsMoving = true;
        } else {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            IsMoving = false;
        }



    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();

    }

    void OnFire() {
        animator.SetTrigger("Attack");
        SwordAttackEffect.Play();
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }
}
