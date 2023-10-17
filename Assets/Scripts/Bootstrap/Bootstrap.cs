using UnityEngine;

[RequireComponent(typeof(PlayerBootstrap))]
[RequireComponent(typeof(ShopBootstrap))]
[RequireComponent(typeof(WavesSystemBootstrap))]
public class Bootstrap : MonoBehaviour
{
    private PlayerBootstrap _playerBootstrap;
    private ShopBootstrap _shopBootstrap;
    private WavesSystemBootstrap _wavesSystemBootstrap;
    
    private IDataProvider _dataProvider;
    private IPersistentData _persistentData;

    private void Awake()
    {
        _playerBootstrap = GetComponent<PlayerBootstrap>();
        _shopBootstrap = GetComponent<ShopBootstrap>();
        _wavesSystemBootstrap = GetComponent<WavesSystemBootstrap>();

        InitData();
        
        _playerBootstrap.Init(_persistentData);
        _shopBootstrap.Init(_dataProvider, _persistentData);
        _wavesSystemBootstrap.Init(_dataProvider, _persistentData);
    }
    
    private void InitData()
    {
        _persistentData = new PersistentData();
        _dataProvider = new LocalDataProvider(_persistentData);

        _dataProvider.LoadOrInit();
    }
}
