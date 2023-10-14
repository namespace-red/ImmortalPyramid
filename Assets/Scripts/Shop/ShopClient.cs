using System;
using UnityEngine;

public class ShopClient : MonoBehaviour
{
    public Wallet Wallet { get; private set; }
    public Inventory Inventory { get; private set; }

    public void Init(Wallet wallet, Inventory inventory)
    {
        Wallet = wallet ?? throw new NullReferenceException(nameof(wallet));
        Inventory = inventory ?? throw new NullReferenceException(nameof(inventory));
    }
    
    public void GiveProduct(GameObject product)
    {
        if (product.TryGetComponent(out Weapon weapon))
        {
            Inventory.Add(weapon);
        }
        else
        {
            throw new AggregateException(nameof(product));
        }
    }
}