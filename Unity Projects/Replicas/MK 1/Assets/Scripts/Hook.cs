using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public Animator playerAnim;
    public Animator enemyAnim;
    public bool hit;
    public GameObject player;
    public GameObject enemy;
    
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyAnim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        anim = GetComponent<Animator>();
        hit = false;
    }

   
    void Update()
    {
        transform.localScale = player.transform.localScale;
        if(player.transform.localScale.x == 1 && hit == false)
        {
            transform.Translate(Vector2.right * speed);
        }
        if (player.transform.localScale.x == -1 && hit == false)
        {
            transform.Translate(Vector2.left * speed);
        }
        if (hit == true)
        {
 
           
            if(transform.localScale.x == 1)
            {
                enemy.transform.Translate(Vector2.left * 0.05f);
                transform.Translate(Vector2.left * 0.05f);
            }
            if (transform.localScale.x == -1)
            {
                enemy.transform.Translate(Vector2.right * 0.05f);
                transform.Translate(Vector2.right * 0.05f);
            }
            if (enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("Blocking"))
            {
                Destroy(gameObject);
            }
            else
            {
                anim.SetTrigger("HookHit");
                playerAnim.SetBool("HookHit", true);
                Destroy(gameObject, 0.5f);

            }
           
           
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        hit = true;
        

    }

 
}
