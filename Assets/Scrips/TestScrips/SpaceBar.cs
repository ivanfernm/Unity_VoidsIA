using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBar : MonoBehaviour
{
   public Food _food;
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
       {
         _food.SubstractLife(10);
       } 
    }
}
