using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationsController : MonoBehaviour
{
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    
    private void OnAttacked() => _animator.SetTrigger(States.Attack);
    // private void OnJumped() => _animator.SetBool(Params.IsJumping, true);
    
    // private void OnGrounded() => _animator.SetBool(Params.IsJumping, false);
    
    private static class Params
    {
        public const string IsRuning = nameof(IsRuning);
        // public const string IsJumping = nameof(IsJumping);
    }
    
    private static class States
    {
        public const string Attack = nameof(Attack);
        public const string Died = nameof(Died);
        
    }
}
