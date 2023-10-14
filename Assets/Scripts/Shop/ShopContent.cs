using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopContent", menuName = "SO/Shop/ShopContent")]
public class ShopContent : ScriptableObject
{
    [SerializeField] private List<WeaponProduct> _weaponProducts;

    public IEnumerable<WeaponProduct> WeaponProducts => _weaponProducts;

    private void OnValidate()
    {
        var productDuplicates = _weaponProducts.GroupBy(p => p.WeaponType)
            .Where(array => array.Count() > 1);
        
        if (productDuplicates.Count() > 0)
            throw new InvalidOperationException(nameof(_weaponProducts));
    }
}
