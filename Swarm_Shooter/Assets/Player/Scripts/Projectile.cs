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
    [SerializeField]
    float SizeIncrease;

    void Update()
    {
        Life();
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
    public void Life()
    {
        LifetimeEnd = Lifetime();
        if(LifetimeEnd)
        {
            Destroy(gameObject);
        }
        transform.localScale = new Vector3(SizeIncrease, SizeIncrease, SizeIncrease);
    }    
}
