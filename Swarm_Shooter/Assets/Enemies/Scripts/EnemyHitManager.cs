using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHitManager : MonoBehaviour
{
    [SerializeField] 
    float maxHitPoints = 10f;
    float hitPoints;
    [SerializeField]
    int pointValue = 1;


    // Start is called before the first frame update
    void Awake()
    {
        hitPoints = maxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireHit(float rawDamage)
    {
        hitPoints -= rawDamage;
        Debug.Log("Was Hit");

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            GameManager.IncrementScore(pointValue);
        }
    }
}
