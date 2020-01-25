using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject hook;
    public GameObject enemy;
    public Animator anim;
    public Rigidbody2D rb;
    public float speed;
    public float jumpVelocity;
    public int timer;
    public static int OnScreenHooks;
    public bool isCrouched;
    public bool jumping;
    public static bool blocking;
    void Start()
    {
        blocking = false;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jumping = false;
        OnScreenHooks = 0;
    }

    
    void Update()
    {
        anim.SetInteger("HookTime", timer);

        if(transform.position.x < enemy.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(transform.position.x > enemy.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (transform.position.y <= -2.19f)
        {
            anim.SetBool("Jumping", false);
            transform.position = new Vector2(transform.position.x, -2.19f);
            jumping = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && jumping == false)
        {
            anim.SetBool("Jumping", true);
            jumping = true;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {

            rb.velocity = new Vector2(speed, rb.velocity.y);
            anim.SetBool("Walking", true);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            anim.SetBool("Walking", true);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("Walking", false);
        }

        if (Input.GetAxis("Vertical") == -1)
        {
            transform.position = new Vector2(transform.position.x, -3.7f);
            isCrouched = true;            
        }
        else
        {
            isCrouched = false;
        }
        if (isCrouched == true && !anim.GetBool("Crouched"))
        {
            anim.SetBool("Crouched", true);            

        }
        if(isCrouched==false && anim.GetBool("Crouched"))
        {
            anim.SetBool("Crouched", false);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetBool("Blocking", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            anim.SetBool("Blocking", false);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("HookThrow"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            timer++;
            if(OnScreenHooks == 0)
            {
                Instantiate(hook, new Vector2(transform.position.x - 1, transform.position.y +1), Quaternion.identity);
                OnScreenHooks++;
            }
            
            
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            timer = 0;
            OnScreenHooks = 0;
        }
        
    }

}

