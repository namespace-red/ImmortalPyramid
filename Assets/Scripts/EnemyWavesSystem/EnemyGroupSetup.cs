public class EnemyGroupSetup : IEnemyGroupSetup
{
    public EnemyType EnemyType { get; }
    public int Count { get; }

    public EnemyGroupSetup(EnemyType enemyType, int count)
    {
        EnemyType = enemyType;
        Count = count;
    }
}
