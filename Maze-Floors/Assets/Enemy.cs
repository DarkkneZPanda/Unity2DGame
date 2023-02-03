using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    bool IsMoving {
        set {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    public float damage = 1f;
    public float moveSpeed = 500f;
    public float knockBackForce = 10f;

    public DetectionZone detectionZone;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    bool isMoving = false;

    bool canMove = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }     
    
    void FixedUpdate() {
        if(canMove == true && detectionZone.detectedObjs.Count > 0) {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            rb.AddForce(direction * moveSpeed * Time.deltaTime);

            if (direction.x < 0){
                spriteRenderer.flipX = true;
            } else if (direction.x > 0){
                spriteRenderer.flipX = false;
            } 
            
            IsMoving = true;

        }else{
            IsMoving = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        Collider2D collider = other.collider;
        IDamageable damageable = collider.GetComponent<IDamageable>(); 

        if (damageable != null) {

            Vector2 direction = (collider.transform.position - transform.position).normalized;

            Vector2 knockBack = direction * knockBackForce;
        
            // other.collider.SendMessage("OnHit", damage, knockback);
            damageable.OnHit(damage, knockBack);
           
        }

    }

    public void LockMovement() {
        canMove = false;
    }

}
