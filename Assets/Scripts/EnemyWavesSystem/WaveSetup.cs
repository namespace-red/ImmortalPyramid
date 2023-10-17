using System.Collections.Generic;
using Newtonsoft.Json;

public class WaveSetup : IWaveSetup
{
    public WaveSetup()
    {
        Setups = new List<IEnemyGroupSetup>();
    }

    [JsonConstructor]
    public WaveSetup(List<IEnemyGroupSetup> setups)
    {
        Setups = setups;
    }

    public List<IEnemyGroupSetup> Setups { get; }

    public void AddEnemies(EnemyType enemyType, int count)
        => Setups.Add(new EnemyGroupSetup(enemyType, count));
}
