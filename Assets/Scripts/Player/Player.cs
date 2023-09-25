using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(PlayerAnimationsController))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private PlayerAnimationsController _animationsController;

    [HideInInspector] public Health Health;
    [HideInInspector] public Wallet Wallet;

    private void Start()
    {
        _currentWeapon = _weapons[0];
        Health = GetComponent<Health>();
        Wallet = GetComponent<Wallet>();
        _animationsController = GetComponent<PlayerAnimationsController>();

        Health.Healing(Health.MaxValue);
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
