using System.Collections.Generic;

public class WaveSetup : IWaveSetup
{
    public List<IEnemyGroupSetup> Setups { get; } = new List<IEnemyGroupSetup>();

    public void AddEnemies(EnemyType enemyType, int count)
        => Setups.Add(new EnemyGroupSetup(enemyType, count));
}
