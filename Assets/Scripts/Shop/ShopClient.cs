using System;
using UnityEngine;

public class ShopClient : MonoBehaviour
{
    private WeaponFactory _weaponFactory;
    private Inventory _inventory;

    public Wallet Wallet { get; private set; }

    public void Init(Wallet wallet, Inventory inventory, WeaponFactory weaponFactory)
    {
        Wallet = wallet ?? throw new NullReferenceException(nameof(wallet));
        _inventory = inventory ?? throw new NullReferenceException(nameof(inventory));
        _weaponFactory = weaponFactory ?? throw new NullReferenceException(nameof(weaponFactory));
    }
    
    public void GiveProduct(ItemType type)
    {
        _inventory.Add(_weaponFactory.Create(type));
    }
}