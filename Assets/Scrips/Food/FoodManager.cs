using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [Header("Food Definition")]
    public Food _food;
    public List<Food> _foodList;
    public int _desiredFoodAmount;

    private int _currentFoodAmount;

    public static FoodManager instance;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        _currentFoodAmount = 0;
        for (var i = 0; i < _desiredFoodAmount; i++)
        {
            Food _currentFood;
            _currentFood = Instantiate(_food, new Vector3(Random.Range(-24,24),0,Random.Range(-12,12)) , Quaternion.identity);
            _currentFood._foodManager = this;
            _foodList.Add(_currentFood);
            _currentFoodAmount++;
        }
    //    Debug.Log(_currentFoodAmount);
    }
    private void Update() 
    {
        if(_currentFoodAmount <= _desiredFoodAmount){AddFood();}
        
    }
    public void AddFood()
    {
        Food _currentFood;
        _currentFood = Instantiate(_food, new Vector3(Random.Range(-24,24),0,Random.Range(-12,12)) , Quaternion.identity);
        _currentFood._foodManager = this;
        _foodList.Add(_currentFood);
        _currentFoodAmount++;
    }
    public void RemoveFood(Food foodToRemove)
    {
        _foodList.Remove(foodToRemove);
        Destroy(foodToRemove);
        _currentFoodAmount--;
    }



  
}
