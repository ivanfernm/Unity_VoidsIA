using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : Istate
{
    Agent _agent;
    StateMachine _fsm;

    public PatrolState(Agent agent, StateMachine fsm){_agent = agent;_fsm = fsm;}
    public void OnExit()
    {
       // throw new System.NotImplementedException();
    }

    public void OnStart()
    {
       // throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
       if (_agent._energy > 0 && !_agent._chase)
       {
           _agent.CalculateWayPoints(); 
           Debug.Log("Haciendo Patrol");
       }
       else if (_agent._energy >0 && _agent._chase)
       {
           _fsm.ChangeState(AgentStates.Persuit);
           Debug.Log("Cambio Persuit");
       }
       else if(_agent._energy < 0)
       {
           _fsm.ChangeState(AgentStates.Idle);
           Debug.Log("cambio a Idle");
       }
    }

}
