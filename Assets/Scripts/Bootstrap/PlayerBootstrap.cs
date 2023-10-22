using System;
using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WeaponFactory _weaponFactory;
    [SerializeField] private BulletFactory _bulletFactory;
    [SerializeField] private Transform _itemsContainer;
    [SerializeField] private Transform _shootPoint;
    
    private IPersistentData _persistentData;

    public void Init(IPersistentData persistentData)
    {
        _persistentData = persistentData ?? throw new NullReferenceException(nameof(persistentData));
        
        InitPlayerData();
    }

    private void InitPlayerData()
    {
        if (_player == null)  throw new NullReferenceException(nameof(_player));
        if (_weaponFactory == null)  throw new NullReferenceException(nameof(_weaponFactory));
        if (_bulletFactory == null)  throw new NullReferenceException(nameof(_bulletFactory));
        if (_itemsContainer == null)  throw new NullReferenceException(nameof(_itemsContainer));
        if (_shootPoint == null)  throw new NullReferenceException(nameof(_shootPoint));
        
        _weaponFactory.Init(_itemsContainer);
        _bulletFactory.Init(_shootPoint);
        _player.Init(_persistentData, _weaponFactory);
    }
}
