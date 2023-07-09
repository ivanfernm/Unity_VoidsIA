using System;
using System.Collections.Generic;
using UnityEngine;

public class NBoidManager : MonoBehaviour
{
        public int boidsAmounts;
        protected CanvasDataManager _canvasDataManager;
        public NBoids _boidsToSpawn;

        public ObjectPool<NBoids> _boidsPool;



        private void Start()
        {
                _canvasDataManager = CanvasDataManager.instance;
                boidsAmounts = (int)_canvasDataManager.amountOfBoids;

                
                _boidsPool = new ObjectPool<NBoids>(CreateBoids, NBoids.TurnOn, NBoids.TurnOff, boidsAmounts);
        }


        private void Update()
        {
                boidsAmounts = (int)_canvasDataManager.amountOfBoids;


        }

        public NBoids CreateBoids()
        {
                return Instantiate(_boidsToSpawn);
        }
}
