using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [Header("Agent Stats")]
    public float _maxSpeed;
    public float _maxforce;
    public float _viewRadius;
    public float _energy;
    public bool _chase;
    public bool _waypointsbool;

    public float RA = 0.005f;

    [SerializeField]Boids _target;

    private Vector3 _velocity;
    private StateMachine _fsm = new StateMachine();

   public List<Transform> waypoints = new List<Transform>(); 

   int _currentWaypoint;

   public BoidManager _boidManager;


   private void Awake() {
       
   }
   private void Start() {


      SetStateMachine();
      //SetState
      _fsm.ChangeState(AgentStates.Patrol);

   }
   private void Update() {
       CheckBounds();
      _energy = Mathf.Clamp(_energy, 0f,100f);
      _fsm.Update();
      //CalculateWayPoints();
      if(CalculateCloserBoid()!= null) _chase = false;
      else{ _chase = true; _waypointsbool = false;}
      
      if(_energy > 0)
      {transform.position += _velocity * Time.deltaTime * _maxSpeed;
       transform.forward = _velocity;
        }
      else
      {
          _velocity = Vector3.zero;
          _fsm.ChangeState(AgentStates.Idle);
      }    
      
     
   }
   public void CalculateWayPoints()
   {

        _waypointsbool = true; 
        Vector3 dir = waypoints[_currentWaypoint].transform.position - transform.position;
        transform.forward = dir;
        transform.position += transform.forward * _maxSpeed * Time.deltaTime;


        if (dir.magnitude <= _viewRadius)
        {
            _currentWaypoint++;
            if (_currentWaypoint > waypoints.Count -1)
            {
                _currentWaypoint = 0;
            }   
        }
        looseEnergy(RA);
   }

   public void Persuit()
   {
       if (CalculateCloserBoid() == null)
       {
            return;      
       }
       _target = CalculateCloserBoid();

       Vector3 _futurePos = _target.transform.position + _velocity;
       Vector3 _desired = _futurePos - transform.position;

       if (Vector3.Distance(_target.transform.position,transform.position) < _velocity.magnitude)
       {
           _desired = _target.transform.position - transform.position;
       }


       _desired = _desired.normalized * _maxSpeed;

       looseEnergy(RA);
       Vector3 _steering = Vector3.ClampMagnitude(_desired-_velocity, _maxforce / 10);
       AddForce(_steering);
   }
   void AddForce(Vector3 _force)
   {
       _velocity += Vector3.ClampMagnitude(_velocity +_force, _maxSpeed);
   }
   public Boids CalculateCloserBoid()
   {
       Boids desiredNewBoids = null;
       foreach (var boid in _boidManager._allBoids)
       {
           Vector3 _directionToTarget = boid.transform.position - transform.position;
           if(_directionToTarget.magnitude > _viewRadius)
           {
               desiredNewBoids = boid as Boids;
               _chase = false;
               return desiredNewBoids;
           }
       }

       //_chase = true;
       return desiredNewBoids;
   }
   
   public void GainEnergy(float energy){_energy = _energy + energy;}
   public void looseEnergy(float energy){_energy = _energy - energy;}

    public float GetEnergy(){return _energy;}
   private void OnDrawGizmos()
   {
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position, _viewRadius);
   }

    
    public void SetStateMachine()
    {

      IdleState _idle = new IdleState(this,_fsm);
      PatrolState _patrol = new PatrolState(this,_fsm);
      PersuitState _flee = new PersuitState(this,_fsm);
      _fsm.AddState(AgentStates.Idle, _idle);
      _fsm.AddState(AgentStates.Patrol , _patrol);
      _fsm.AddState(AgentStates.Persuit , _flee);
    }
    
     void CheckBounds()
    {
        Vector3 newPosition = transform.position;

        if (transform.position.z > 12) newPosition.z = -11.5f;
        if (transform.position.z < -12) newPosition.z = 11.5f;
        if (transform.position.x > 27) newPosition.x = -26.5f;
        if (transform.position.x < -27) newPosition.x = 26.5f;

        transform.position = newPosition;
    }
}
