using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopProductViewFactory", menuName = "SO/Shop/ShopProductViewFactory")]
public class ShopProductViewFactory : ScriptableObject
{
    [SerializeField] private ShopProductView _weaponProductViewPrefab;

    public ShopProductView Create(ShopProduct product, Transform parent)
    {
        ShopProductView instance;

        switch (product)
        {
            case WeaponProduct weaponProduct:
                instance = Instantiate(_weaponProductViewPrefab, parent);
                break;
            
            default:
                throw new ArgumentException(nameof(product));
        }
        
        instance.Init(product);
        return instance;
    }
}
