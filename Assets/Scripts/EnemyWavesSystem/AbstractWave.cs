using UnityEngine.Events;

public abstract class AbstractWave
{
    public UnityAction SpawnedLastEnemy;
    public UnityAction<int, int> SpawnedEnemy;
    public UnityAction<AbstractWave> Finished;

    public abstract void Start();
}