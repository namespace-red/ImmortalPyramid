using System;
using UnityEngine;

public class WavesSystemBootstrap : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private WaveFactory _waveFactory;
    [SerializeField] private WaveSystem _waveSystem;
    [SerializeField] private GameObject _enemyTarget;
    [SerializeField] private Transform _spawnPoint;
    
    private IDataProvider _dataProvider;
    private IPersistentData _persistentData;

    public void Init(IDataProvider dataProvider, IPersistentData persistentData)
    {
        _dataProvider = dataProvider ?? throw new NullReferenceException(nameof(dataProvider));
        _persistentData = persistentData ?? throw new NullReferenceException(nameof(persistentData));
        if (_enemyFactory == null) throw new NullReferenceException(nameof(_enemyFactory));
        if (_waveFactory == null) throw new NullReferenceException(nameof(_waveFactory));
        if (_waveSystem == null) throw new NullReferenceException(nameof(_waveSystem));
        if (_enemyTarget == null) throw new NullReferenceException(nameof(_enemyTarget));
        if (_spawnPoint == null) throw new NullReferenceException(nameof(_spawnPoint));

        if (_enemyTarget.TryGetComponent(out ITargetWithHeathData target) == false)
            throw new ArgumentException($"{nameof(_enemyTarget)} doesn't have {typeof(ITargetWithHeathData)}");
    
        _enemyFactory.Init(_spawnPoint, target);
        _waveFactory.Init(_enemyFactory, _persistentData);
        _waveSystem.Init(_dataProvider, _persistentData, _waveFactory);
    }
}
