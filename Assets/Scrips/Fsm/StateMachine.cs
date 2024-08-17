using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private Istate _currentState;

    public Dictionary<AgentStates,Istate> _stateList = new Dictionary<AgentStates, Istate>(); 
    // Update is called once per frame
    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.OnUpdate();   
        }
    }

    public void AddState(AgentStates name,Istate state)
    {
        if(!_stateList.ContainsKey(name)) _stateList.Add(name,state);
    }

    public void ChangeState(AgentStates newState){

        if (!_stateList.ContainsKey(newState))
        {
          return;   
        }
        _currentState?.OnExit();
        _currentState = _stateList[newState];
        _currentState.OnStart();

    }
}

    public enum AgentStates
    {
        Idle,
        Patrol,
        Persuit,
        Atack,
        Defend,
        Foward,
    }