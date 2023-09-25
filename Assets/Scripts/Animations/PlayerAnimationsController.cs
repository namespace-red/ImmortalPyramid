using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class PlayerAnimationsController : MonoBehaviour, IAttackAnimation,
    IMovementAnimation, IDeathAnimation
{
    private Animator _animator;
    private Health _health;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Died += PlayDeath;
    }

    private void OnDisable()
    {
        _health.Died -= PlayDeath;
    }

    // private void OnJumped() => _animator.SetBool(Params.IsJumping, true);
    // private void OnGrounded() => _animator.SetBool(Params.IsJumping, false);
 
    public void PlayAttack()
    {
        _animator.SetTrigger(States.Shoot);
    }

    public void SetMoveState(bool state)
    {
         _animator.SetBool(Params.IsRuning, state);
    }

    public void PlayDeath()
    {
        _animator.SetTrigger(States.Died);
    }

    private static class Params
    {
        public const string IsRuning = nameof(IsRuning);
        // public const string IsJumping = nameof(IsJumping);
    }

    private static class States
    {
        public const string Shoot = nameof(Shoot);
        public const string Died = nameof(Died);
    }
}
