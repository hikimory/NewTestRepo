using System.Collections;
using System.Linq;
using System.Collections.Generic;
using VR.Toolkit;
using UnityEngine;
using System;


public class State : IState
{
    private List<Type> _transitions = null;

    public virtual bool CanTransact(IState state)
    {
        if (_transitions == null) return false;
        return _transitions.Any(x => x == state.GetType());
    }

    public virtual void Enter()
    {
        Debug.Log($"Exter to state {nameof(State)}");
    }

    public virtual void Exit()
    {
        Debug.Log($"Exit from state {nameof(State)}");
    }

    public virtual void Update()
    {
        Debug.Log($"Update in state {nameof(State)}");
    }

    public void AddTransition(Type stateType)
    {
        if (_transitions == null) _transitions = new List<Type>();
        _transitions.Add(stateType);
    }
}
