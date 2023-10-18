using System;

public class VictoryState : IState
{
    private readonly IVictoryAnimation _animation;

    public VictoryState(IVictoryAnimation animation)
    {
        _animation = animation ?? throw new NullReferenceException(nameof(animation));
    }

    public void Enter()
        => _animation.PlayVictory();

    public void Exit() { }

    public void Tick() { }
}