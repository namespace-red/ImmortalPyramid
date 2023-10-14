using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(PlayerAnimationsController))]
[RequireComponent(typeof(ShopClient))]
public class Player : MonoBehaviour, ITargetWithHeathData
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private PlayerAnimationsController _animationsController;
    private Inventory _inventory;

    public Transform Transform => transform;
    public Health Health { get; private set; }
    public Wallet Wallet { get; private set; }
    public ShopClient ShopClient { get; private set; }
    public Weapon CurrentWeapon { get; private set; }

    public void Init(IPersistentData persistentData)
    {
        _animationsController = GetComponent<PlayerAnimationsController>();
        Health = GetComponent<Health>();
        Wallet = GetComponent<Wallet>();
        ShopClient = GetComponent<ShopClient>();
        _inventory = GetComponent<Inventory>();
        
        Wallet.Init(persistentData);
        _inventory.Init(persistentData);
        ShopClient.Init(Wallet, _inventory);
        
        CurrentWeapon = (Weapon)_inventory.GetCurrentItem();
        Health.Healing(Health.MaxValue);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CurrentWeapon.Shoot(_shootPoint);
            _animationsController.PlayAttack();
        }
    }
}
