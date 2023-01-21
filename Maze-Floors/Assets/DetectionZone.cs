using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{   
    public string Target = "Player";
    public List<Collider2D> detectedObjs = new List<Collider2D>();
    public Collider2D col;

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == Target){
            detectedObjs.Add(collider);
        }
        
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == Target){
            detectedObjs.Remove(collider);
        }
        
    }
}
