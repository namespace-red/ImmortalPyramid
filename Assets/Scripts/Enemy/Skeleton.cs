using System;
using UnityEngine;

[RequireComponent(typeof(SkeletonAnimationsController))]
[RequireComponent(typeof(MoveTowardsTarget))]
[RequireComponent(typeof(MeleeAreaAttack))]
public class Skeleton : Enemy
{
    private SkeletonAnimationsController _animationsController;
    private StateMachine _stateMachine;
    
    private void Awake()
    {
        _animationsController = GetComponent<SkeletonAnimationsController>();
        Health = GetComponent<Health>();
        Move = GetComponent<MoveTowardsTarget>();
        Attack = GetComponent<MeleeAreaAttack>();
        
        EnemyType = EnemyType.Skeleton;
    }

    private void Update()
    {
        _stateMachine?.Tick();
    }

    public void Init(ITargetWithHeathData target)
    {
        target = target ?? throw new ArgumentException("Target can't be null");
        
        Move.Target = target.Transform;
        
        StateMachineFactory smFactory = new StateMachineFactory();
        _stateMachine = smFactory.CreateEnemyStateMachine(
            this, target, _animationsController);
    }
}
