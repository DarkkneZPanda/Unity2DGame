using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAssets : MonoBehaviour
{
    private static ShopAssets items;

    public static ShopAssets item {
        get {
            if(items == null) 
                items = Instantiate(Resources.Load<ShopAssets>("ShopAssets"));
            return items;
        }
    }

    public Sprite s_damageUp;
    public Sprite s_healthUp;
}
