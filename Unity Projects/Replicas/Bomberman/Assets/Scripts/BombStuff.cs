using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStuff : MonoBehaviour
{
    public GameObject explodeCenterPrfb;
    public float explodeTimer;
    private float timer;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
        timer += Time.deltaTime;
        if(timer >= explodeTimer)
        {
            DestroyAfter();
        }
    }
    void DestroyAfter()
    {
        Instantiate(explodeCenterPrfb, transform.position , Quaternion.identity);
        Destroy(gameObject);
        
    }
}
