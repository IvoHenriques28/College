using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatKill : MonoBehaviour
{
    public GameObject fatBoi;
 
    void Start()
    {
        fatBoi = GameObject.FindGameObjectWithTag("FatZombie");
  
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, fatBoi.transform.position) < 1)
        {
            Destroy(gameObject);
        }
       
    }
}
