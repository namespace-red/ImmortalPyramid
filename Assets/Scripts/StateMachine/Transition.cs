using System;

public class Transition
{
    // Func is implemented in inheritors of StateMachine
    public Transition(IState nextState, Func<bool> isReadyToTransition)
    {
        NextState = nextState;
        IsReadyToTransition = isReadyToTransition;
    }
        
    public IState NextState { get; }
    public Func<bool> IsReadyToTransition { get; }
}
