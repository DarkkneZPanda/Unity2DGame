using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{
    private DamageableCharacter Defeat;
    private PlayerInput Lock;

    void Start() {
        Defeat = GameObject.Find("Player").GetComponent<DamageableCharacter>();
        Lock = GameObject.Find("Player").GetComponent<PlayerInput>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && other.tag == "Enemy") {
            Defeat.Health = 0;
            Lock.LockMovement();
        }
    }
}
