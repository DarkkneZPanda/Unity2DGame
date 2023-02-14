using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemManager>playerInventory = new List<ItemManager>();
    private Dictionary<ItemData, ItemManager>itemDictionary = new Dictionary<ItemData, ItemManager>();

    private void OnEnable() {
        Coin.OnCoinCollected += AddData;
    }

    private void OnDisable() {
        Coin.OnCoinCollected -= AddData;
    }
    public void AddData(ItemData itemData) {
        if(itemDictionary.TryGetValue(itemData, out ItemManager item)) {
            item.AddItem();
        } else {
            ItemManager newItem = new ItemManager(itemData);
            playerInventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
        }
    }

    public void RemoveData(ItemData itemData) {
        if(itemDictionary.TryGetValue(itemData, out ItemManager item)) {
            item.RemoveItem();
            if(item.stackSize == 0) {
                playerInventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
        }
    }
}
