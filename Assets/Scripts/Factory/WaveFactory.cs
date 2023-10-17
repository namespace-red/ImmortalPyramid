using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveFactory", menuName = "SO/Factory/WaveFactory")]
public class WaveFactory : ScriptableObject
{
    private EnemyFactory _enemyFactory;
    private IPersistentData _persistentData;

    public void Init(EnemyFactory enemyFactory, IPersistentData persistentData)
    {
        _enemyFactory = enemyFactory ?? throw new ArgumentException(nameof(enemyFactory));
        _persistentData = persistentData ?? throw new ArgumentException(nameof(persistentData));
    }

    public AbstractWave Create(int waveNumber)
    {
        return new Wave(_persistentData.WavesData.AllWavesSetup.Get(waveNumber), _enemyFactory);
    }
}
