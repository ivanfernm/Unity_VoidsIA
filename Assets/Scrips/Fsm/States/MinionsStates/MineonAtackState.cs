using UnityEngine;


public class MineonAtackState : Istate
{
    Mineon _agent;
    StateMachine _fsm;

    //Constructor
    public MineonAtackState(Mineon agent,StateMachine fsm){_agent = agent; _fsm = fsm;}
    public void OnStart()
    {
    }

    public void OnUpdate()
    {
        Debug.Log("imatacking");
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }
}