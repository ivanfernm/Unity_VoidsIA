using UnityEngine;


public class MinionsDefendState : Istate
{
    Mineon _agent;
    StateMachine _fsm;
    //Constructor
    public MinionsDefendState(Mineon agent,StateMachine fsm){_agent = agent; _fsm = fsm;}
    public void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }
}