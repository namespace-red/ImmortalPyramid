using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(PlayerAnimationsController))]
[RequireComponent(typeof(ShopClient))]
public class Player : MonoBehaviour, ITargetWithHeathData
{
    [SerializeField] private Transform _shootPoint;

    private PlayerAnimationsController _animationsController;
    private Inventory _inventory;

    public Transform Transform => transform;
    public Health Health { get; private set; }
    public Wallet Wallet { get; private set; }
    public ShopClient ShopClient { get; private set; }
    public Weapon CurrentWeapon => (Weapon)_inventory.GetCurrentItem();

    public void Init(IPersistentData persistentData, WeaponFactory weaponFactory)
    {
        _animationsController = GetComponent<PlayerAnimationsController>();
        Health = GetComponent<Health>();
        Wallet = GetComponent<Wallet>();
        ShopClient = GetComponent<ShopClient>();
        _inventory = GetComponent<Inventory>();
        
        if (persistentData == null) throw new NullReferenceException(nameof(persistentData));
        if (weaponFactory == null) throw new NullReferenceException(nameof(weaponFactory));
        
        Wallet.Init(persistentData);
        _inventory.Init(persistentData, weaponFactory);
        ShopClient.Init(Wallet, _inventory, weaponFactory);
        
        Health.Healing(Health.MaxValue);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && CurrentWeapon.CanAttack)
        {
            CurrentWeapon.Shoot(_shootPoint);
            _animationsController.PlayAttack();
        }
    }
}
