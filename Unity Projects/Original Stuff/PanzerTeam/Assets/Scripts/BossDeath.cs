using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
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
        if(count < 10)
        {
            anim.SetInteger("Bullet", 1);
        }
        if(count == 10)
        {
            SceneManager.LoadScene(4);
        }
        
    }
}
