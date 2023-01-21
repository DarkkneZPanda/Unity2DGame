using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    // bool IsMoving {
        // set {
            // isMoving = value;
            // animator.SetBool("isMoving", isMoving);
        // }
    // }

    public float damage = 1f;
    public float moveSpeed = 500f;
    public float knockBackForce = 10f;

    public DetectionZone detectionZone;
    Rigidbody2D rb;
    Animator animator;

    // bool isMoving = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();     
    }
    void FixedUpdate() {
        if(detectionZone.detectedObjs.Count > 0) {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            rb.AddForce(direction * moveSpeed * Time.deltaTime); 
            // IsMoving = true;
        }else{
            // IsMoving = false;
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

}
