using System;
using UnityEngine;

[RequireComponent(typeof(PlayerBootstrap))]
[RequireComponent(typeof(ShopBootstrap))]
public class Bootstrap : MonoBehaviour
{
    private PlayerBootstrap _playerBootstrap;
    private ShopBootstrap _shopBootstrap;
    
    private IDataProvider _dataProvider;
    private IPersistentData _persistentData;

    private void Awake()
    {
        _playerBootstrap = GetComponent<PlayerBootstrap>();
        _shopBootstrap = GetComponent<ShopBootstrap>();

        InitializeData();
        
        _playerBootstrap.Init(_persistentData);
        _shopBootstrap.Init(_dataProvider, _persistentData);
    }
    
    private void InitializeData()
    {
        _persistentData = new PersistentData();
        _dataProvider = new DataLocalProvider(_persistentData);

        LoadDataOrInit();
    }

    private void LoadDataOrInit()
    {
        if (_dataProvider.TryLoad() == false)
        {
            _persistentData.PlayerData = new PlayerSavingData();
            Debug.Log("Loaded default saves");
        }
        else
        {
            Debug.Log("Loaded saves");
        }
    }
}
