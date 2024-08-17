using System;
using System.Collections.Generic;
using UnityEngine;


public class MineonManager : MonoBehaviour
{
    //create singleton
    public static MineonManager instance;

    public Tower CurrentObjective;

    public List<Mineon> CurrentMineons = new List<Mineon>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }
}