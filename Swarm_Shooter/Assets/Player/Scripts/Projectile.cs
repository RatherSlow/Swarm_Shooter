using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public LayerMask whatIsBees;

    [SerializeField]
    float tick;
    [SerializeField]
    float maxLifetime;
    bool LifetimeEnd;

    void Update()
    {
        Destruction();
    }


    public bool Lifetime()
    {
    if (tick < maxLifetime)
        {
            tick += Time.deltaTime;
            return false;
        }
        return true;
    }
    public void Destruction()
    {
        LifetimeEnd = Lifetime();
        if(LifetimeEnd)
        {
            Destroy(gameObject);
        }
    }    
}
