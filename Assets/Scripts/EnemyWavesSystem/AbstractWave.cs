using UnityEngine.Events;

public abstract class AbstractWave
{
    public UnityAction LastEnemyCameOut;
    public UnityAction<AbstractWave> Finished;

    public abstract void Start();
}