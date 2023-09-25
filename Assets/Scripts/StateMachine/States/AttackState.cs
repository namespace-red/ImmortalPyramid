using System;

public class AttackState : IState
{
    private readonly IAttacking _attacker;
    private IAttackAnimation _animation;
    public AttackState(IAttacking attacker, IAttackAnimation animation)
    {
        _attacker = attacker ?? throw new ArgumentException("AttackState._attacker can't be null");
        _animation = animation ?? throw new ArgumentException("AttackState._animation can't be null");
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
