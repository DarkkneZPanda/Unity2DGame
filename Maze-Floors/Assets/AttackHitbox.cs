using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public Collider2D attackCollider;
    public float damage = 1;
    public float knockBackForce = 15f;
    public Vector3 Right = new Vector3(0.2f, -0.1f, 0);
    public Vector3 Left = new Vector3(-0.2f, -0.1f, 0);
    

    

    void Start() {
    }


    void OnCollisionEnter2D(Collision2D other) {

        IDamageable damageableObject = other.collider.GetComponent<IDamageable>();

        if (damageableObject !=null) {


        Vector3 parentPosition = transform.parent.position;    

        Vector2 direction = (Vector2)(other.gameObject.transform.position - parentPosition).normalized;

        Vector2 knockBack = direction * knockBackForce;
    
        // other.collider.SendMessage("OnHit", damage, knockback);
        damageableObject.OnHit(damage, knockBack);
        } 
    }

    void isFacingRight(bool isFacingRight) {
        if(isFacingRight) {
            gameObject.transform.localPosition = Right;
        } else{
            gameObject.transform.localPosition = Left;
        }
    }
    
}
