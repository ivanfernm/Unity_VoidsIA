using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersuitState : Istate
{
    Agent _agent;
    StateMachine _fsm;

    public PersuitState(Agent agent,StateMachine fsm){_agent = agent;_fsm = fsm;}
    public void OnExit()
    {
        //hrow new System.NotImplementedException();
    }

    public void OnStart()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        if (_agent._energy > 0)
        {
            if (_agent._chase)
            {
                _agent.Persuit();
                Debug.Log(" haciendo Persuit");
            }   
            else if(!_agent._chase)
            {_fsm.ChangeState(AgentStates.Patrol);
            Debug.Log("Cambio a Patrol");
            }
        }
        else _fsm.ChangeState(AgentStates.Idle);
    }
}
