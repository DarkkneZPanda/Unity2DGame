using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class DamageableCharacter : MonoBehaviour, IDamageable
{

    [SerializeField] private AudioSource HitSoundEffect;
    [SerializeField] private AudioSource DeathSoundEffect;
    public static event Action GameOver;
    public static event Action OnPLayerDamaged;
    public bool invincibilityEnabled = false;
    public float invincibilityTime = 0.25f;

    private float invincibleTimeElapsed = 0f;
    Animator animator;
    Rigidbody2D rb;
    public float Health {
        set {
            health = value;

            if(health <= 0) {
                Defeated();
                 
            }

        }
        get {
            return health;
        }
    }

    public bool Invincible { get {
        return invincible;
    }
        
    set {
        invincible = value;

        if(invincible == true) {
            invincibleTimeElapsed = 0f;
        }   
        }
    }

    public bool invincible = false;

    public float health, maxHealth;

    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    public void GameOverScreen() {
        GameOver?.Invoke();
    }

    public void Defeated() {
        animator.SetTrigger("Defeated");
        DeathSoundEffect.Play();

    }

    public void RemoveEnemy() {
        Destroy(gameObject);

    }

    public void Hit() {
        animator.SetTrigger("Hit");
        HitSoundEffect.Play();

    }

    public void OnHit(float damage, Vector2 knockBack)
    {
        if (!Invincible) {
            Health -= damage;
            Hit();
            OnPLayerDamaged?.Invoke();

            rb.AddForce(knockBack, ForceMode2D.Impulse);

            if(invincibilityEnabled) {
                Invincible = true;
            }
        }


    }

    public void OnHit(float damage)
    {
        if (!Invincible) {
            Health -= damage;

            if(invincibilityEnabled) {
                Invincible = true;
            }

        }
    }

    public void FixedUpdate() {
        if(Invincible) {
            invincibleTimeElapsed += Time.deltaTime;

            if(invincibleTimeElapsed > invincibilityTime) {
                Invincible = false;
            }
        }
    }
}