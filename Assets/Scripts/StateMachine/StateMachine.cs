using System;
using UnityEngine;

public class StateMachine
{
    private IState _currentState;
    private TransitionsController _transitions = new TransitionsController();

    public void Tick()
    {
        var transition = _transitions.TryGetReadyTransition(_currentState);
        
        if (transition != null)
            SetState(transition.NextState);
        
        _currentState?.Tick();
    }

    public void AddTransition(IState fromState, IState toState, Func<bool> transitionCondition)
    {
        var transition = _transitions.CreateTransition(toState, transitionCondition);
        _transitions.AddTransitionByState(fromState, transition);
    }
    
    public void AddTransitionFromAnyStates(IState toState, Func<bool> transitionCondition)
    {
        var transition = _transitions.CreateTransition(toState, transitionCondition);
        _transitions.AddTransitionFromAnyStates(transition);
    }
    
    public void SetState(IState newState)
    {
        _currentState?.Exit();

        _currentState = newState;
        _transitions.SetCurrentState(_currentState);
        _currentState.Enter();
    }
}
