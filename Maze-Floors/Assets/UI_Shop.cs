using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopTemplate;
    
    private void Awake() {
        container = transform.Find("container");
        shopTemplate = container.Find("ShopTemplate");
        shopTemplate.gameObject.SetActive(true);  
    }

    private void Start() {
        CreateItem(Items.GetSprite(Items.ItemType.damageUp), "Damage Up",  Items.GetCost(Items.ItemType.damageUp), 0);
        CreateItem(Items.GetSprite(Items.ItemType.healthUp), "Health Up", Items.GetCost(Items.ItemType.healthUp), 1);
    }

    private void CreateItem(Sprite itemSprite, string itemName, int itemCost, int positionIndex) {
        Transform shopItemTransform = Instantiate(shopTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 200f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("ItemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("ShopPrice").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;
    }
}
