using System;

public abstract class StateMachine
{
    private readonly TransitionsController _transitions = new TransitionsController();
    private IState _currentState;

    public void Tick()
    {
        var transition = _transitions.TryGetReadyTransition(_currentState);
        
        if (transition != null)
            SetState(transition.NextState);
        
        _currentState?.Tick();
    }

    protected void AddTransition(IState fromState, IState toState, Func<bool> transitionCondition)
    {
        var transition = TransitionsController.CreateTransition(toState, transitionCondition);
        _transitions.AddTransitionByState(fromState, transition);
    }
    
    protected void AddTransitionFromAnyStates(IState toState, Func<bool> transitionCondition)
    {
        var transition = TransitionsController.CreateTransition(toState, transitionCondition);
        _transitions.AddTransitionFromAnyStates(transition);
    }

    protected void SetState(IState newState)
    {
        _currentState?.Exit();

        _currentState = newState;
        _transitions.SetCurrentState(_currentState);
        _currentState.Enter();
    }
}
