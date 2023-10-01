using System.Collections.Generic;

public interface IWaveSetup
{
    public List<IEnemyGroupSetup> Setups { get; }
    
    public void AddEnemies(EnemyType enemyType, int count);
}
