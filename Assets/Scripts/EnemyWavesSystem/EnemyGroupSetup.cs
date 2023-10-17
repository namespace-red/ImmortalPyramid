using Newtonsoft.Json;

public class EnemyGroupSetup : IEnemyGroupSetup
{
    [JsonConstructor]
    public EnemyGroupSetup(EnemyType enemyType, int count)
    {
        EnemyType = enemyType;
        Count = count;
    }
    
    public EnemyType EnemyType { get; }
    public int Count { get; }
}
