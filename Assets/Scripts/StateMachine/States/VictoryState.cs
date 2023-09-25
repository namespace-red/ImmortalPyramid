using System;

public class VictoryState : IState
{
    private IVictoryAnimation _animation;

    public VictoryState(IVictoryAnimation animation)
    {
        _animation = animation ?? throw new ArgumentException("VictoryState._animation can't be null");
    }

    public void Enter()
        => _animation.PlayVictory();

    public void Exit() { }

    public void Tick() { }
}