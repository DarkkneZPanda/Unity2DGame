using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public int cashValue = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Inventory inventory = other.GetComponent<Inventory>();

            if (inventory != null) {
                inventory.Money = inventory.Money + cashValue;
                print ("Money = " + inventory.Money);
                gameObject.SetActive(false);
            }
        }
    }
}
