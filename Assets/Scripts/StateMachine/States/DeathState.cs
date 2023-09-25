using System;
using UnityEngine;

public class DeathState : IState
{
    private readonly Vector2 _deathPoint;
    private IDeathAnimation _animation;
    // private readonly IPhysicsRewardsFactory _rewardsFactory;
    
    public DeathState(Vector2 point, IDeathAnimation animation)
    {
        _deathPoint = point;
        _animation = animation ?? throw new ArgumentException("DeathState._animation can't be null");
        // _rewardsFactory = rewardsFactory ?? throw new ArgumentException("AttackState._attacker can't be null");
    }
    
    public void Enter()
    {
        _animation.PlayDeath();
        // => _rewardsFactory.Create(_deathPoint);
    }

    public void Exit() { }

    public void Tick() { }
}