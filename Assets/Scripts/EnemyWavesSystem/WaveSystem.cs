using System;
using UnityEngine;
using UnityEngine.Events;

public class WaveSystem : MonoBehaviour
{
    public UnityAction StartedWave;
    public UnityAction SpawnedAllEnemiesInWave;
    public UnityAction<int, int> SpawnedEnemy;
    public UnityAction Finished;

    [SerializeField] private Wallet _wallet;

    private IDataProvider _dataProvider;
    private IPersistentData _persistentData;
    private WaveFactory _waveFactory;

    private int CurrentWaveNumber
    {
        get => _persistentData.WavesData.CurrentWaveNumber;
        set => _persistentData.WavesData.CurrentWaveNumber = value;
    }

    public void Init(IDataProvider dataProvider, IPersistentData persistentData, WaveFactory waveFactory)
    {
        _dataProvider = dataProvider ?? throw new NullReferenceException(nameof(dataProvider));
        _persistentData = persistentData ?? throw new NullReferenceException(nameof(persistentData));
        _waveFactory = waveFactory ?? throw new NullReferenceException(nameof(waveFactory));
    }

    public void StartNextWave()
    {
        ++CurrentWaveNumber;
        
        var newWave = _waveFactory.Create(CurrentWaveNumber);
        newWave.SpawnedLastEnemy += OnLastEnemyHasLeft;
        newWave.SpawnedEnemy += SpawnedEnemy;
        newWave.Finished += OnWaveFinished;
        newWave.Start();
        
        StartedWave?.Invoke();
    }

    private void OnLastEnemyHasLeft()
    {
        if (IsCurrentWaveLast()) 
            return;
        
        SpawnedAllEnemiesInWave?.Invoke();
    }
    
    private bool IsCurrentWaveLast()
        => CurrentWaveNumber == _persistentData.WavesData.AllWavesSetup.WaveCount;
    
    private void OnWaveFinished(AbstractWave finishedWave)
    {
        finishedWave.SpawnedLastEnemy -= OnLastEnemyHasLeft;
        finishedWave.Finished -= OnWaveFinished;

        if (IsCurrentWaveLast())
            Finished?.Invoke();

        _wallet.TryAddMoney(20);
        
        _dataProvider.Save();
    }
}
