using System;

public class WaveFactory
{
    private readonly EnemyFactory _enemyFactory;
    private readonly AllWavesSetup _allWavesSetup;

    public WaveFactory(EnemyFactory enemyFactory, AllWavesSetup allWavesSetup)
    {
        _enemyFactory = enemyFactory ?? throw new ArgumentException("FollowState._enemyFactory can't be null");
        _allWavesSetup = allWavesSetup ?? throw new ArgumentException("FollowState._allWavesSetup can't be null");
    }

    public AbstractWave Create(int waveNumber)
    {
        AbstractWave newAbstractWave = new Wave(
            _allWavesSetup.Get(waveNumber), _enemyFactory);
        
        return newAbstractWave;
    }
}
