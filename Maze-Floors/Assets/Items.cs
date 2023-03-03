using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items 
{
    public enum ItemType {
        damageUp,
        healthUp
    }

    public static int GetCost(ItemType itemType) {
        switch (itemType) {
            default:
            case ItemType.damageUp:     return 10;
            case ItemType.healthUp:     return 25;
        }
    }

    public static Sprite GetSprite(ItemType itemType) {
        switch (itemType) {
            default:
            case ItemType.damageUp:     return ShopAssets.item.s_damageUp;
            case ItemType.healthUp:     return ShopAssets.item.s_healthUp;
        }
    }
}
