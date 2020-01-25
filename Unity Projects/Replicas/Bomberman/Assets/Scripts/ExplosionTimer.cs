using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimer : MonoBehaviour
{
    private int timer = 1;
    void Start()
    {
        DestroyAfter();
    }


    void Update()
    {

    }
    void DestroyAfter()
    {
        Destroy(gameObject, timer);

    }
}
