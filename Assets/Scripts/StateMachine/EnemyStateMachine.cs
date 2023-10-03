using System;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    private readonly Enemy _enemy;
    private readonly ITargetWithHeathData _targetWithHeath;
    private readonly IEnemyAnimationsController _animationsController;
    
    public EnemyStateMachine(Enemy enemy, ITargetWithHeathData targetWithHeath, IEnemyAnimationsController animationsController)
    {
        _enemy = enemy ?? throw new ArgumentException("EnemyStateMachine._enemy can't be null");
        _targetWithHeath = targetWithHeath ?? throw new ArgumentException("EnemyStateMachine._targetWithHeath can't be null");
        _animationsController = animationsController ?? throw new ArgumentException("EnemyStateMachine._animationsController can't be null");
        
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
            _targetWithHeath.Transform.position) <= _enemy.Attack.Radius;

    private bool IsTargetFar()
        => Vector2.Distance(_enemy.Attack.AttackPoint.position,
            _targetWithHeath.Transform.position) > _enemy.Attack.Radius;

    private bool IsTargetDead()
        => _targetWithHeath.Health.IsAlive == false;
    
    private bool IsDead()
        => _enemy.Health.IsAlive == false;
}
