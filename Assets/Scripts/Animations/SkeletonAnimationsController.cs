using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SkeletonAnimationsController : MonoBehaviour, IEnemyAnimationsController
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(States.Attack);
    }

    public void SetMoveState(bool state)
    {
        if (state)
            _animator.SetTrigger(States.Walk);
    }

    public void PlayVictory()
    {
        _animator.SetTrigger(States.React);
    }

    public void PlayDeath()
    {
        _animator.SetTrigger(States.Dead);
    }
    
    private static class States 
    {
        public const string Idle = nameof(Idle);
        public const string Walk = nameof(Walk);
        public const string Attack = nameof(Attack);
        public const string Dead = nameof(Dead);
        public const string React = nameof(React);
        
    }
}
