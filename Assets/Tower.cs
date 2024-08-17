using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public float maxlife = 100;
    public Life _life => new Life(maxlife);

    [SerializeField] private Image lifebar;


    //atackrange
    [SerializeField] private float _atackRange;


    //atackRate
    [SerializeField] private float _atackrate;
    [SerializeField] private float _atackdamage;


    //enemy list;
    public List<Mineon> _Mineons = new List<Mineon>();

    //target
    public Mineon targe;

    void Start()
    {
        lifebar.fillAmount = _life.getLife() / 100f;
        _Mineons = MineonsByOrder();
    }

    public List<Mineon> MineonsByOrder()
    {
        //todo fix this logic to order by closer
        var result = MineonManager.instance.CurrentMineons;
        result.OrderByDescending(x => Vector3.Distance(transform.position, x.transform.position));

        return result;
    }


    // Update is called once per frame
    void Update()
    {
        if (targe == null) targe = TargetByDistance(_Mineons);
        else StartCoroutine(Atack(_atackrate));
        
        

    }

    public Mineon TargetByDistance(List<Mineon> a)
    {
        return a.First();
    }
    public IEnumerator Atack(float Rate)
    {
        while (true)
        {
            //dect the mineon i want to atack
            //todo replace for a corrutine
            targe = _Mineons.First();
            //atack
            targe.getDamage(_atackdamage);
            //check life o the target and if its dead change tartget

            yield return new WaitForSeconds(Rate);
        }
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _atackRange);
    }
}