using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopContent", menuName = "SO/Shop/ShopContent")]
public class ShopContent : ScriptableObject
{
    [SerializeField] private List<ShopProduct> _products;

    public IEnumerable<ShopProduct> Products => _products;

    private void OnValidate()
    {
        var productDuplicates = _products.GroupBy(p => p.Type)
            .Where(array => array.Count() > 1);
        
        if (productDuplicates.Count() > 0)
            throw new InvalidOperationException(nameof(_products));
    }
}
