using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemManager : MonoBehaviour
{
    public ItemData itemData;
    public int stackSize;

    public ItemManager(ItemData item) {
        itemData = item;
        AddItem();
    }

    public void AddItem() {
        stackSize++;
    }

    public void RemoveItem() {
        stackSize--;
    }
}