using System;

public class FollowState : IState
{
    private readonly IMovableTowardsTarget _movement;
    private IMovementAnimation _animation;
    
    public FollowState(IMovableTowardsTarget movement, IMovementAnimation animation)
    {
        _movement = movement ?? throw new ArgumentException("FollowState._movement can't be null");
        _animation = animation ?? throw new ArgumentException("FollowState._animation can't be null");
    }

    public void Enter()
    {
        _animation.SetMoveState(true);
        _movement.Move();
    }

    public void Exit()
    {
        _animation.SetMoveState(false);
        _movement.Stop();
    }

    public void Tick() { }
}
