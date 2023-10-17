using System;
using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WeaponFactory _weaponFactory;
    [SerializeField] private Transform _itemsContainer;
    
    private IPersistentData _persistentData;

    public void Init(IPersistentData persistentData)
    {
        _persistentData = persistentData ?? throw new NullReferenceException(nameof(persistentData));
        
        InitPlayerData();
    }

    private void InitPlayerData()
    {
        if (_player == null)  throw new NullReferenceException(nameof(_player));
        if (_itemsContainer == null)  throw new NullReferenceException(nameof(_itemsContainer));
        if (_weaponFactory == null)  throw new NullReferenceException(nameof(_weaponFactory));
        
        _weaponFactory.Init(_itemsContainer);
        _player.Init(_persistentData, _weaponFactory);
    }
}
