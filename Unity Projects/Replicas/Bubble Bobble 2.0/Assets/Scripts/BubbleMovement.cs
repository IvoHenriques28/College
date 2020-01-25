using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    private Animator anim;
    public float speed;
    public bool floatingUp;
    public float timer;

    void Start()
    {
        anim = GetComponent<Animator>();
        floatingUp = true;
    }

    void Update()
    {
        timer = timer + 1;
        
        if (floatingUp == true)
        {
            transform.Translate(Vector2.up * speed);
        }
        if(floatingUp == false)
        {
            transform.Translate(Vector2.down * speed);
        }
       if(transform.position.y <= 2.5)
        {
            floatingUp = true;
        }
       if(transform.position.y >= 12.5)
        {
            floatingUp = false;
        }
        if (timer >= 600)
        {
            anim.SetFloat("Timer", timer);
        }
        if(timer >= 610)
        {
            Destroy(gameObject);
        }
    }
}
