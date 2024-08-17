using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Mineon : MonoBehaviour
{
    //tiene 3 states foward, and  atack, defend.
    //in the foward state it runs foward. 
    //in  the atack cas a atack 
    //in the defend it protect itself from the tower 

    //playable variables
    public float speed = 3;
    public float maxlife = 10;
    public Life life => new Life(maxlife);

    [SerializeField] private float range;

    public bool isTargetingTorret;
    
    //Canvas items
    [SerializeField] private Image lifeBar;

    //declarate the fsm variable
    private StateMachine _fsm = new StateMachine();

    //function that set the statemachine states
    public void SetStateMachine()
    {
        //build the states
        MineonFowardState _fowardState = new MineonFowardState(this, _fsm);
        MineonAtackState _atackState = new MineonAtackState(this, _fsm);
        MinionsDefendState _defendState = new MinionsDefendState(this, _fsm);

        //add to the fsm

        _fsm.AddState(AgentStates.Foward, _fowardState);
        _fsm.AddState(AgentStates.Atack, _atackState);
        _fsm.AddState(AgentStates.Defend, _defendState);
    }


    void Start()
    {
        MineonManager.instance.CurrentMineons.Add(this);

        //set the state machine
        SetStateMachine();
        
        //set lifebar ONSTART
        lifeBar.fillAmount = life.getLife() / 100;

        //set the first state
        _fsm.ChangeState(AgentStates.Foward);
    }


    void Update()
    {
        _fsm.Update();
    }

    public void LookForObjective()
    {
        var currentENpos = MineonManager.instance.CurrentObjective.transform.position;
        var dist = Vector3.Distance(transform.position, currentENpos);
        if (dist <= range )
        {
            Debug.Log("tower in the range, ready to swap to  atack mode");
            isTargetingTorret = true;
        }
    }

    public void getDamage(float damageDeal)
    {
        var a = damageDeal;
        life.decreaseLide(a, 10f);
        Debug.Log(this.name + life.getLife());

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}