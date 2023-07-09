using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
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

    public List<Boids> _allBoids = new List<Boids>();
    public Boids _boidPrefab;
    public static BoidManager instance;

    public Vector3 _boidStartPoint;
    
    public int _desiredBoidAmount;
    private int _currentBoidAmount;
    
    private void Awake() {
        if (instance == null)
        {
            instance = this;   
        }
        else Destroy(gameObject);
    }
    void Start()
    {
        _currentBoidAmount = 0;
        var positionToSpawn = new Vector3(Random.Range(-24, 24), 0, Random.Range(-12, 12));
        for (var i = 0; i < _desiredBoidAmount; i++)
        {
            Boids _currentBoid;
            _currentBoid = Instantiate(_boidPrefab,positionToSpawn ,Quaternion.identity);
            _currentBoid._boidManager = instance;
            _allBoids.Add(_currentBoid);
            _currentBoidAmount++;
            
        }
        
    }
}
