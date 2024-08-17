using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life 
{
    private float maxlife { get; set; }
    private float currentLife { get; set;}

    public Life(float Initiallife)
    {
        maxlife = Initiallife;
        currentLife = maxlife;
    }
    
    public float getLife()
    {
        return currentLife;
    }

    public IEnumerator decreaseLide(float amountToDecrease, float decreaseLifeTme)
    {
        var elipsetime = 0f;
        elipsetime += Time.deltaTime;

        var t = Mathf.Clamp01(elipsetime / decreaseLifeTme);

        var b = Mathf.Clamp(currentLife - amountToDecrease, 0, maxlife);

        currentLife = Mathf.Lerp(currentLife, b, t);

        yield return null;
    }

    public IEnumerator increaseLife(float amountToincrease, float decreaseLifeTme)
    {
        var elipsetime = 0f;
        elipsetime += Time.deltaTime;

        var t = Mathf.Clamp01(elipsetime / decreaseLifeTme);

        var b = Mathf.Clamp(currentLife + amountToincrease, 0, maxlife);
        
        currentLife = Mathf.Lerp(currentLife,b , t);

        yield return null;
        
    }

}
