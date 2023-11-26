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
    float maxLifetime = 4f;
    bool LifetimeEnd;
    [SerializeField]
    float SizeIncrease;
    [SerializeField]
    float startingsize;
    [SerializeField]
    float rawDamage = 10;
    private Vector3 startSize;
    private Vector3 scaleChange;

    private void Awake()
    {
        startSize = new Vector3(startingsize, startingsize, startingsize);
        scaleChange = new Vector3(SizeIncrease, SizeIncrease, SizeIncrease);
    }

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
        transform.localScale = startSize + scaleChange * tick;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            interact(collider);
        }
    }
    public void interact(Collider collider)
    {
        collider.SendMessageUpwards("FireHit", rawDamage, SendMessageOptions.DontRequireReceiver);
    }
    //OnTriggerStay or just Ontrigger and damage * Time.deltatime or damage then give effect "On Fire"
}
