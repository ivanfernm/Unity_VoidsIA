using UnityEngine;

public class MineonFowardState : Istate
{
    Mineon _agent;
    StateMachine _fsm;
    //Constructor
    public MineonFowardState(Mineon agent,StateMachine fsm){_agent = agent; _fsm = fsm;}
    
    public void OnStart()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        //move forward until i or im in range to atack the torret.
        _agent.gameObject.transform.position += Vector3.right * _agent.speed * Time.deltaTime;

        if (_agent.isTargetingTorret == false)
        {
            _agent.LookForObjective();
        }
        else
        {
            _fsm.ChangeState(AgentStates.Atack);
        }
    }

    public void OnExit()
    {
        //throw new System.NotImplementedException();
    }
}