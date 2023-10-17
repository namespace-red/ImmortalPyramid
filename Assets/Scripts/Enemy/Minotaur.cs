using System;
using UnityEngine;

[RequireComponent(typeof(MinotaurAnimationsController))]
[RequireComponent(typeof(MoveTowardsTarget))]
[RequireComponent(typeof(MeleeAreaAttack))]
public class Minotaur : Enemy
{
    [SerializeField] private StateMachineFactory _stateMachineFactory;
    
    private MinotaurAnimationsController _animationsController;
    private StateMachine _stateMachine;
    
    private void Awake()
    {
        _animationsController = GetComponent<MinotaurAnimationsController>();
        Health = GetComponent<Health>();
        Move = GetComponent<MoveTowardsTarget>();
        Attack = GetComponent<MeleeAreaAttack>();
        
        EnemyType = EnemyType.Minotaur;
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
