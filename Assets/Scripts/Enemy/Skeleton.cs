using System;
using UnityEngine;

[RequireComponent(typeof(SkeletonAnimationsController))]
[RequireComponent(typeof(MoveTowardsTarget))]
[RequireComponent(typeof(MeleeAreaAttack))]
public class Skeleton : Enemy
{
    [SerializeField] private StateMachineFactory _stateMachineFactory;

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
        if (target == null) throw new NullReferenceException(nameof(target));
        Move.Target = target.Transform;
        
        _stateMachine = _stateMachineFactory.CreateEnemyStateMachine(
            this, target, _animationsController);
    }
}
