using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(PlayerAnimationsController))]
public class Player : MonoBehaviour, ITargetWithHeathData
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private PlayerAnimationsController _animationsController;
    private Weapon _currentWeapon;
    private Health _health;
    private Wallet _wallet;

    public Transform Transform => transform;
    public Health Health => _health;
    public Wallet Wallet => _wallet;

    private void Awake()
    {
        _currentWeapon = _weapons[0];
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
        _animationsController = GetComponent<PlayerAnimationsController>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
            _animationsController.PlayAttack();
        }
    }
}
