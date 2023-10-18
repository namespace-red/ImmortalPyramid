using System;

public class AttackState : IState
{
    private readonly IAttacking _attacker;
    private readonly IAttackAnimation _animation;
    
    public AttackState(IAttacking attacker, IAttackAnimation animation)
    {
        _attacker = attacker ?? throw new NullReferenceException(nameof(attacker));
        _animation = animation ?? throw new NullReferenceException(nameof(animation));
    }
    
    public void Enter() { }

    public void Exit() {  }

    public void Tick()
    {
        if (_attacker.CanAttack)
        {
            _attacker.Attack();
            _animation.PlayAttack();
        }
    }
}
