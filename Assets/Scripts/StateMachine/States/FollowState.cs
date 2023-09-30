using System;

public class FollowState : IState
{
    private readonly IMovableTowardsTarget _movement;
    private readonly IMovementAnimation _animation;
    
    public FollowState(IMovableTowardsTarget movement, IMovementAnimation animation)
    {
        _movement = movement ?? throw new ArgumentException("FollowState._movement can't be null");
        _animation = animation ?? throw new ArgumentException("FollowState._animation can't be null");
    }

    public void Enter()
    {
        _movement.StartMove();
        _animation.SetMoveState(true);
    }

    public void Exit()
    {
        _movement.StopMove();
        _animation.SetMoveState(false);
    }

    public void Tick() { }
}
