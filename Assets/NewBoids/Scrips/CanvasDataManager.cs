using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDataManager : MonoBehaviour
{
    public static CanvasDataManager instance;
    
    public float amountOfBoids { get; set;}

    private Slider boidsAmountSlider;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (boidsAmountSlider == null)
        {
            boidsAmountSlider = gameObject.GetComponentInChildren<Slider>();
            amountOfBoids = boidsAmountSlider.value;
        }
        else Debug.Log("no slider");
        
    }

    private void Update()
    {
        amountOfBoids = boidsAmountSlider.value;
    }

    private void UpdateValues()
    {
        amountOfBoids = boidsAmountSlider.value;
    }
}