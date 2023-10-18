using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MinotaurAnimationsController : MonoBehaviour, IEnemyAnimationsController
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
        _animator.SetBool(Params.IsRuning, state);
    }

    public void PlayVictory()
    {
        _animator.SetTrigger(States.Victory);
    }

    public void PlayDeath()
    {
        _animator.SetTrigger(States.Dead);
    }

    private static class Params
    {
        public const string IsRuning = nameof(IsRuning);
    }
    
    private static class States 
    {
        public const string Attack = nameof(Attack);
        public const string Dead = nameof(Dead);
        public const string Victory = nameof(Victory);
    }
}