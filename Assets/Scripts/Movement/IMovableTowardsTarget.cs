using UnityEngine;

public interface IMovableTowardsTarget
{
    public Transform Target { get; set; }
    
    public void StartMove();
    public void StopMove();
}
