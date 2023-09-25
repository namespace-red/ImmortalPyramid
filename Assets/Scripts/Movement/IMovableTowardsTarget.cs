using UnityEngine;

public interface IMovableTowardsTarget : IMovable
{
    public Transform Target { get; }
    
    public void Stop();
}
