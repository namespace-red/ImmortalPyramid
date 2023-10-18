using System;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    private const float AttackDistanceOffset = .25f;
    private readonly Enemy _enemy;
    private readonly Health _targetHealth;
    private readonly Collider2D _targetCollider2D;
    private readonly IEnemyAnimationsController _animationsController;
    
    public EnemyStateMachine(Enemy enemy, ITargetWithHeathData targetWithHeath, IEnemyAnimationsController animationsController)
    {
        _enemy = enemy ?? throw new NullReferenceException(nameof(enemy));
        if (targetWithHeath == null) throw new NullReferenceException(nameof(targetWithHeath));
        _targetHealth = targetWithHeath.Health;
        _targetCollider2D = targetWithHeath.Transform.GetComponent<Collider2D>();
        _animationsController = animationsController ?? throw new NullReferenceException(nameof(animationsController));
        
        Init();
    }
    
    private void Init()
    {
        IState followState  = new FollowState(_enemy.Move, _animationsController);
        IState attackState  = new AttackState(_enemy.Attack, _animationsController);
        IState deathState   = new DeathState(_enemy.GetComponent<CapsuleCollider2D>(), _animationsController);
        IState victoryState = new VictoryState(_animationsController);
        
        AddTransition(followState, attackState, IsTargetNearby);
        AddTransition(followState, victoryState, IsTargetDead);
        AddTransition(attackState, followState, IsTargetFar);
        AddTransition(attackState, victoryState, IsTargetDead);
        AddTransitionFromAnyStates(deathState, IsDead);
        
        SetFirstState(followState);
    }

    private void SetFirstState(IState state)
    {
        SetState(state);
    }

    private bool IsTargetNearby()
        => Vector2.Distance(_enemy.Attack.AttackPoint.position,
            _targetCollider2D.ClosestPoint(_enemy.Attack.AttackPoint.position)) + AttackDistanceOffset < _enemy.Attack.Radius;

    private bool IsTargetFar()
        => Vector2.Distance(_enemy.Attack.AttackPoint.position,
            _targetCollider2D.ClosestPoint(_enemy.Attack.AttackPoint.position)) + AttackDistanceOffset > _enemy.Attack.Radius;

    private bool IsTargetDead()
        => _targetHealth.IsAlive == false;
    
    private bool IsDead()
        => _enemy.Health.IsAlive == false;
}
