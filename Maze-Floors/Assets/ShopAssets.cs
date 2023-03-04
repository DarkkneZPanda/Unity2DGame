using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAssets : MonoBehaviour
{
    private static ShopAssets _items;

    public static ShopAssets item {
        get {
            if(_items == null) 
                _items = Instantiate(Resources.Load<ShopAssets>("ShopAssets"));
            return _items;
        }
    }

    public Sprite damageUp;
    public Sprite healthUp;
}
