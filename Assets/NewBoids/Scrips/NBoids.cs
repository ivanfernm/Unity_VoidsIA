using System;
using UnityEngine;
public class NBoids : MonoBehaviour
{
    public static void TurnOn(NBoids e){ e.gameObject.SetActive(true);}
    public static void TurnOff(NBoids e){ e.gameObject.SetActive(false);}

    public int Aradius;

    public float MaxSpeed;

    private Vector3 _velocity;

    private void Start()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }

    void ApplyForce(Vector3 force)
    {
        //MaxSpeed clamp the force 
        _velocity = Vector3.ClampMagnitude(_velocity + force, MaxSpeed);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position,Aradius);
    }

    void ChechBounds()
    {
        
    }
}