using System;
using UnityEngine;
using UnityEngine.Events;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    
    private int _currentWaveNumber;
    private WaveFactory _waveFactory;
    private readonly AllWavesSetup _allWavesSetup = new AllWavesSetup();

    public UnityAction StartedWave;
    public UnityAction SpawnedAllEnemiesInWave;
    public UnityAction<int, int> SpawnedEnemy;
    public UnityAction Finished;

    private void Awake()
    {
        IWaveSetup waveSetup1 = new WaveSetup();
        waveSetup1.AddEnemies(EnemyType.Minotaur, 5);
        IWaveSetup waveSetup2 = new WaveSetup();
        waveSetup2.AddEnemies(EnemyType.Minotaur, 8);
        
        _allWavesSetup.Add(waveSetup1);
        _allWavesSetup.Add(waveSetup2);

        _enemyFactory = _enemyFactory ?? throw new NullReferenceException("WaveSystem._enemyFactory can't be null");
        _waveFactory = new WaveFactory(_enemyFactory, _allWavesSetup);
    }

    public void StartNextWave()
    {
        ++_currentWaveNumber;
        
        AbstractWave newWave = _waveFactory.Create(_currentWaveNumber);
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
        => _currentWaveNumber == _allWavesSetup.WaveCount;
    
    private void OnWaveFinished(AbstractWave finishedWave)
    {
        finishedWave.SpawnedLastEnemy -= OnLastEnemyHasLeft;
        finishedWave.Finished -= OnWaveFinished;

        if (_currentWaveNumber == _allWavesSetup.WaveCount)
            Finished?.Invoke();
    }
}
