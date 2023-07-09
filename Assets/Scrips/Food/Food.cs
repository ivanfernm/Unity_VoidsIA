using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int _maxLife;
   [SerializeField]
    private float _currentLife;

    public FoodManager _foodManager;

    private void Start() {
        _currentLife = _maxLife;
    }
    private void Update() {
        if (_currentLife <= 0)
        {
            _foodManager.RemoveFood(this);
            Destroy(gameObject);
        }
    }
    public void SubstractLife(float AmountToSubstract)
    {
        float time = 2f;
        _currentLife -= AmountToSubstract * Time.deltaTime / time;
    }
}
