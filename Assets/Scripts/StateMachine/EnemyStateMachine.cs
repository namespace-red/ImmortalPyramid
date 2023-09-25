using System;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    private Enemy _enemy;
    private Player _target;
    private EnemyAnimationsController _animationsController;
    
    public EnemyStateMachine(Enemy enemy, Player target, EnemyAnimationsController animationsController)
    {
        _enemy = enemy ?? throw new ArgumentException("EnemyStateMachine._enemy can't be null");
        _target = target ?? throw new ArgumentException("EnemyStateMachine._target can't be null");
        _animationsController = animationsController ?? throw new ArgumentException("EnemyStateMachine._animationsController can't be null");
        
        Init();
    }
    
    private void Init()
    {
        IState followState  = new FollowState(_enemy.Move, _animationsController);
        IState attackState  = new AttackState(_enemy.Attack, _animationsController);
        IState deathState   = new DeathState(_enemy.transform.position, _animationsController);
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
        => Vector2.Distance(_enemy.transform.position,
            _target.transform.position) <= _enemy.Attack.Radius;

    private bool IsTargetFar()
        => Vector2.Distance(_enemy.transform.position,
            _target.transform.position) > _enemy.Attack.Radius;

    private bool IsTargetDead()
        => _target.Health.IsAlive == false;
    
    private bool IsDead()
        => _enemy.Health.IsAlive == false;
}
