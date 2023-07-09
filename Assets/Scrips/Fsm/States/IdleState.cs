using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Istate 
{
    Agent _agent;
    StateMachine _fsm;

    public IdleState(Agent agent,StateMachine fsm){_agent = agent; _fsm = fsm;}
    public void OnExit()
    {
        //throw new System.NotImplementedException();
    }

    public void OnStart()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
       _agent.GainEnergy(_agent.RA * 2);
       Debug.Log("Hace Iddle");
       if (_agent._energy >= 10)
       {
            if (_agent._chase == true)
            {
                _fsm.ChangeState(AgentStates.Persuit); 
                Debug.Log("Cambia A persuit");
            }
            else _fsm.ChangeState(AgentStates.Patrol);
            Debug.Log("cambia a patrol"); 
       }

    }

}
