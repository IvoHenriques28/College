using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatDeath : MonoBehaviour
{
    public int count;
    public GameObject bullet;
    public Animator anim;
    void Start()
    {
        count = 0;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        bullet = GameObject.FindGameObjectWithTag("Bullet");

        if(Vector2.Distance(transform.position, bullet.transform.position) < 1)
        {
            Destroy(bullet.gameObject);
            count++;
        }
        if(count == 1)
        {
            anim.SetInteger("Bullet", 1);
        }
        if(count == 2)
        {
            anim.SetInteger("Bullet", 2);
            Destroy(gameObject);
            HUD.points = HUD.points + 5;
        }
        
    }
}
