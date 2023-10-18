using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

public class DeathState : IState
{
    private readonly Collider2D _collider2D;
    private readonly IDeathAnimation _animation;
    
    public DeathState(Collider2D collider2D, IDeathAnimation animation)
    {
        _collider2D = collider2D ?? throw new NullReferenceException(nameof(collider2D));
        _animation = animation ?? throw new NullReferenceException(nameof(animation));
    }
    
    public void Enter()
    {
        _collider2D.enabled = false;
        _collider2D.attachedRigidbody.isKinematic = true;
        
        _animation.PlayDeath();
        
        Object.Destroy(_collider2D.gameObject, 3);
    }

    public void Exit() { }

    public void Tick() { }
}