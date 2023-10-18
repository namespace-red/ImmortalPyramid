using System;

public class FollowState : IState
{
    private readonly IMovableTowardsTarget _movement;
    private readonly IMovementAnimation _animation;
    
    public FollowState(IMovableTowardsTarget movement, IMovementAnimation animation)
    {
        _movement = movement ?? throw new NullReferenceException(nameof(movement));
        _animation = animation ?? throw new NullReferenceException(nameof(animation));
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
