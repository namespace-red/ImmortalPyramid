using Newtonsoft.Json;

public class WavesSavingData
{
    public WavesSavingData()
    {
        IWaveSetup waveSetup1 = new WaveSetup();
        waveSetup1.AddEnemies(EnemyType.Minotaur, 3);
        IWaveSetup waveSetup2 = new WaveSetup();
        waveSetup2.AddEnemies(EnemyType.Skeleton, 4);
        IWaveSetup waveSetup3 = new WaveSetup();
        waveSetup3.AddEnemies(EnemyType.Minotaur, 2);
        waveSetup3.AddEnemies(EnemyType.Skeleton, 3);
        IWaveSetup waveSetup4 = new WaveSetup();
        waveSetup4.AddEnemies(EnemyType.Minotaur, 4);
        waveSetup4.AddEnemies(EnemyType.Skeleton, 4);
        IWaveSetup waveSetup5 = new WaveSetup();
        waveSetup5.AddEnemies(EnemyType.Skeleton, 5);
        waveSetup5.AddEnemies(EnemyType.Minotaur, 4);
        IWaveSetup waveSetup6 = new WaveSetup();
        waveSetup6.AddEnemies(EnemyType.Minotaur, 6);
        waveSetup6.AddEnemies(EnemyType.Skeleton, 4);
        IWaveSetup waveSetup7 = new WaveSetup();
        waveSetup7.AddEnemies(EnemyType.Skeleton, 6);
        waveSetup7.AddEnemies(EnemyType.Minotaur, 6);
        IWaveSetup waveSetup8 = new WaveSetup();
        waveSetup8.AddEnemies(EnemyType.Minotaur, 5);
        waveSetup8.AddEnemies(EnemyType.Skeleton, 6);        
        waveSetup8.AddEnemies(EnemyType.Minotaur, 4);
        IWaveSetup waveSetup9 = new WaveSetup();
        waveSetup9.AddEnemies(EnemyType.Skeleton, 4);
        waveSetup9.AddEnemies(EnemyType.Minotaur, 7);
        waveSetup9.AddEnemies(EnemyType.Skeleton, 6);
        IWaveSetup waveSetup10 = new WaveSetup();
        waveSetup10.AddEnemies(EnemyType.Skeleton, 5);
        waveSetup10.AddEnemies(EnemyType.Minotaur, 5);
        waveSetup10.AddEnemies(EnemyType.Skeleton, 7);
        waveSetup10.AddEnemies(EnemyType.Minotaur, 8);
        
        AllWavesSetup = new AllWavesSetup();
        AllWavesSetup.Add(waveSetup1);
        AllWavesSetup.Add(waveSetup2);
        AllWavesSetup.Add(waveSetup3);
        AllWavesSetup.Add(waveSetup4);
        AllWavesSetup.Add(waveSetup5);
        AllWavesSetup.Add(waveSetup6);
        AllWavesSetup.Add(waveSetup7);
        AllWavesSetup.Add(waveSetup8);
        AllWavesSetup.Add(waveSetup9);
        AllWavesSetup.Add(waveSetup10);
    }

    [JsonConstructor]
    public WavesSavingData(AllWavesSetup allWavesSetup, int currentWaveNumber)
    {
        AllWavesSetup = allWavesSetup;
        CurrentWaveNumber = currentWaveNumber;
    }
    
    public AllWavesSetup AllWavesSetup { get; }
    public int CurrentWaveNumber { get; set; }
}
