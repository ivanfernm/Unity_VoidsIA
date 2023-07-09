using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{
    [Header("Movement Variables")]
    public float _maxSpeed;
    public float _maxforce;
    
    [Header("Steering Variables")]
    public float _viewRadius;
    public float _foodViewRadius;

    [Header("Boid Variables")]
    public float _separarionWeight;
    public float _alignmentWeight;
    public float _cohesionWeight;
    public float _arriveRadius;

    public Vector3 _velocity;
    public Food _target;
    public BoidManager _boidManager;

    public FoodManager _foodManager;
    
    private void Awake() {
        _foodManager = FoodManager.instance;
    }
    void Start()
    {
        #region Reareangevariables
            _maxSpeed = _boidManager._maxSpeed;
            _maxforce = _boidManager._maxforce;
            _viewRadius = _boidManager._viewRadius;
            _foodViewRadius = _boidManager._foodViewRadius;
            _separarionWeight = _boidManager._separarionWeight;
            _alignmentWeight = _boidManager._alignmentWeight;
            _cohesionWeight = _boidManager._cohesionWeight;
            _arriveRadius = _boidManager._arriveRadius;
            #endregion
      // _target = GetCloserFood();
        Vector3 desired  = _target.transform.position;
        desired = desired.normalized * _maxSpeed;
        ApllyForce(desired);

    }
    private void Update() {
        #region Reareangevariables
        _maxSpeed = _boidManager._maxSpeed;
        _maxforce = _boidManager._maxforce;
        _viewRadius = _boidManager._viewRadius;
        _foodViewRadius = _boidManager._foodViewRadius;
        _separarionWeight = _boidManager._separarionWeight;
        _alignmentWeight = _boidManager._alignmentWeight;
        _cohesionWeight = _boidManager._cohesionWeight;
        _arriveRadius = _boidManager._arriveRadius;
        #endregion
        //_target = GetCloserFood();
        CheckBounds();
        //if(transform.position != _target.transform.position)
        ApllyForce(Separation() * _separarionWeight + Cohesion() * _cohesionWeight + Alignment() * _alignmentWeight);
        Arrive();
        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
        //EatFood();
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _foodViewRadius);
    }

    void ApllyForce(Vector3 force)
    {
        _velocity =  Vector3.ClampMagnitude(_velocity + force, _maxSpeed);
    }   
#region Floking
    Vector3 Separation()
    {
        Vector3 _desired = new Vector3();
        foreach (var boid in _boidManager._allBoids)
        {
          if (boid == this) continue;   
          Vector3 _distance = boid.transform.position - transform.position;
          if (_distance.magnitude < 1)
          {
            _desired.x += _distance.x;
            _desired.z += _distance.z;   
          }

        }
        if(_desired == Vector3.zero) return _desired;
        _desired *=  -1;
        _desired = _desired.normalized * _maxSpeed;

        Vector3 _steering = _desired - _velocity;
        _steering = Vector3.ClampMagnitude(_steering, _maxforce/10);
        return(_steering);
    }

    Vector3 Alignment()
    {
        Vector3 _desired = new Vector3();
        int count  =  0;
        
        foreach (var boid in _boidManager._allBoids)
        {
            if(boid == this) continue;
            if (Vector3.Distance(boid.transform.position,transform.position) < _viewRadius)
            {
                _desired += boid._velocity;
                _desired.y = 0;
                count++;
            }
            
        }
        if(count == 0 )return _desired;
        _desired /= count;


        return (CalculateSteering(_desired));
    }
    Vector3 Cohesion()
    {
       Vector3 _desired = new Vector3();
       int count = 0;
       foreach (var boid in _boidManager._allBoids)
       {
            if(boid == this) continue;
            if (Vector3.Distance(boid.transform.position, transform.position) < _viewRadius)
            {
                _desired += boid.transform.position;
                _desired.y = 0;
                count++;   
            }   
       } 
       if(count == 0) return _desired;
       
       _desired /= count;
       _desired = _desired - transform.position;
       
       return (CalculateSteering(_desired));
    }

    Vector3 CalculateSteering(Vector3 desired)
    {
        desired = desired.normalized * _maxSpeed;

        Vector3 _steering  = desired - _velocity;
        _steering = Vector3.ClampMagnitude(_steering, _maxforce / 10);
        return _steering;
    }

    void Arrive()
    {
        Vector3 _desired = _target.transform.position - transform.position;
        _desired.Normalize();

        float _speed = _maxSpeed;
        float  _distanceToTarget = Vector3.Distance(_target.transform.position , transform.position);
        if(_distanceToTarget < _arriveRadius)
        {
            _speed = _maxSpeed * (_distanceToTarget / _arriveRadius);
        }

        _desired *= _speed;
        
        Vector3 _steering = _desired - _velocity; 
        _steering = Vector3.ClampMagnitude(_steering, _maxSpeed/10);
        ApllyForce(_steering);
        
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
#endregion
/*
#region  FoodDetection
Food GetCloserFood()
{
    Food _closerFood = null;
    float closestDistanceSqr = Mathf.Infinity;
    Vector3 currentPosition = gameObject.transform.position;

    foreach (var food in _foodManager._foodList)
    {
        Vector3 _directionToTarget = food.transform.position - currentPosition;
        float dSqrToTarget = _directionToTarget.sqrMagnitude;
        if (dSqrToTarget < closestDistanceSqr)
        {
            closestDistanceSqr = dSqrToTarget;
            _closerFood =  food;
        }

    }
    return _closerFood;
}

public void EatFood()
{
    Food _currentFood = _target; 
     
    
      Vector3 _distance = _currentFood.transform.position - transform.position;
        if (_distance.magnitude < _foodViewRadius)
          {
            _currentFood.SubstractLife(100);
          }

}
#endregion */
}
