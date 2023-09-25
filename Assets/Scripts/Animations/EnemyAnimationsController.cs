using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimationsController : MonoBehaviour, IAttackAnimation,
    IMovementAnimation, IVictoryAnimation, IDeathAnimation
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
        _animator.SetTrigger(States.Died);
    }

    private static class Params
    {
        public const string IsRuning = nameof(IsRuning);
    }


    private static class States 
    {
        public const string Attack = nameof(Attack);
        public const string Died = nameof(Died);
        public const string Victory = nameof(Victory);
        
    }
}