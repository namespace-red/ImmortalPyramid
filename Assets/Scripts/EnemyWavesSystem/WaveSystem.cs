using System;
using UnityEngine;
using UnityEngine.Events;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    
    private int _currentWaveNumber;
    private WaveFactory _waveFactory;
    private readonly AllWavesSetup _allWavesSetup = new AllWavesSetup();

    public UnityAction AllEnemiesInWaveCameOut;
    public UnityAction Finished;

    private void Awake()
    {
        IWaveSetup waveSetup1 = new WaveSetup();
        waveSetup1.AddEnemies(EnemyType.Minotaur, 2);
        IWaveSetup waveSetup2 = new WaveSetup();
        waveSetup2.AddEnemies(EnemyType.Minotaur, 3);
        
        _allWavesSetup.Add(waveSetup1);
        _allWavesSetup.Add(waveSetup2);

        _enemyFactory = _enemyFactory ?? throw new NullReferenceException("WaveSystem._enemyFactory can't be null");
        _waveFactory = new WaveFactory(_enemyFactory, _allWavesSetup);
    }

    public void StartNextWave()
    {
        ++_currentWaveNumber;
        
        AbstractWave newWave = _waveFactory.Create(_currentWaveNumber);
        newWave.LastEnemyCameOut += OnLastEnemyHasLeft;
        newWave.Finished += OnWaveFinished;
        newWave.Start();
    }

    private void OnLastEnemyHasLeft()
    {
        if (IsCurrentWaveLast()) 
            return;
        
        AllEnemiesInWaveCameOut?.Invoke();
    }
    
    private bool IsCurrentWaveLast()
        => _currentWaveNumber == _allWavesSetup.WaveCount;
    
    private void OnWaveFinished(AbstractWave finishedWave)
    {
        finishedWave.LastEnemyCameOut -= OnLastEnemyHasLeft;
        finishedWave.Finished -= OnWaveFinished;

        if (_currentWaveNumber == _allWavesSetup.WaveCount)
            Finished?.Invoke();
    }
}
