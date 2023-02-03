using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{
    private DamageableCharacter DefeatPlayer;
    private PlayerInput Lock;

    void Start() {
        DefeatPlayer = GameObject.Find("Player").GetComponent<DamageableCharacter>();
        Lock = GameObject.Find("Player").GetComponent<PlayerInput>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            DefeatPlayer.Defeated();
            Lock.LockMovement();
        }
    }
}
