using System.Threading.Tasks;

public class Wave : AbstractWave
{
    private readonly IWaveSetup _waveSetup;
    private readonly EnemyFactory _enemyFactory;
    private readonly int _waitSeconds = 1;

    public Wave(IWaveSetup waveSetup, EnemyFactory enemyFactory)
    {
        _waveSetup = waveSetup;
        _enemyFactory = enemyFactory;
    }

    private int AllEnemiesCount { get; set; }
    private int SpawnedEnemiesCount { get; set; }
    private int DiedEnemiesCount { get; set; }

    public override void Start()
    {
#pragma warning disable 4014
        StartEnemySpawningAsync();
#pragma warning restore 4014
    }

    private async Task StartEnemySpawningAsync()
    {
        foreach (var enemyGroupSetup in _waveSetup.Setups)
            AllEnemiesCount += enemyGroupSetup.Count;

        for (var i = 0; i < _waveSetup.Setups.Count; i++)
        {
            var enemyGroupSetup = _waveSetup.Setups[i];
            
            for (int j = 0; j < enemyGroupSetup.Count; j++)
            {
                var newEnemy = _enemyFactory.Create(enemyGroupSetup.EnemyType);

                newEnemy.Health.Died += () =>
                {
                    if (++DiedEnemiesCount == AllEnemiesCount)
                        Finished?.Invoke(this);
                };

                SpawnedEnemy?.Invoke(++SpawnedEnemiesCount, AllEnemiesCount);

                if (IsLastEnemy(i, j) == false)
                    await Task.Delay(_waitSeconds * 1000);
            }
        }

        SpawnedLastEnemy?.Invoke();
    }

    private bool IsLastEnemy(int enemyGroupNumber, int enemyNumber)
    {
        return (enemyGroupNumber == _waveSetup.Setups.Count - 1) &&
               (enemyNumber == _waveSetup.Setups[enemyGroupNumber].Count - 1);
    }
}
