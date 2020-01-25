using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastKill : MonoBehaviour
{
    public GameObject bullet;
    void Start()
    {
        
    }

   
    void Update()
    {
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        if (Vector2.Distance(transform.position, bullet.transform.position) < 1)
        {
            Destroy(bullet.gameObject);
            Destroy(gameObject);
            HUD.points = HUD.points + 10;
        }
    }
}
