using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopTemplate;
    
    private void Awake() {
        container = transform.Find("container");
        shopTemplate = container.Find("shopTemplate");
        shopTemplate.gameObject.SetActive(false);  
    }
}
