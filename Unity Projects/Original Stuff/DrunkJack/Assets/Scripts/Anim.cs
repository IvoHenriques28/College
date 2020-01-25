using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    Animator Animation;
    private float vy = 0;
    private float JumpForce;
    private float gravity = 0.1f;
    bool OnTheGround;
    bool OnSomeObject;
    bool crouch = false;
    public bool Drop;
    int RandomFall;
    public Player player;
    public bool barrier;
    bool jumping = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, -0.27f);
        Animation = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumping)
        {
          //  Animation.ResetTrigger("Kick");
        }   
        // Debug.Log(OnSomeObject);
        //RandomFall =(int) Random.Range(0, 10000);
        if (RandomFall == 1)
        {
            Animation.SetTrigger("DrunkRun");
        }
        if (player.transform.position.y > 5)
        {
            Animation.SetTrigger("Fly");
        }

        Animation.ResetTrigger("JumpUp");
        Animation.ResetTrigger("JumpDown");
        if (player.vy > 0)
        {
            Animation.SetTrigger("JumpUp");
        }
        if (player.vy < 0 && player.transform.position.y > -4)
        {
            Animation.SetTrigger("JumpDown");
        }
        if (Input.GetButton("Fire2"))
        {
            Animation.SetBool("Crouch", true);
            crouch = true;
        }
        else
        {
            Animation.SetBool("Crouch", false);
            crouch = false;
        }
      if(player.speed == 0)
        {
            Animation.SetTrigger("Idle");
        }
        if (player.collide == true)
        {
            Animation.SetBool("Push",true);
        }
        if (player.collide == false)
        {
            Animation.SetBool("Push", false);
        }

    }

  
        void OnTriggerEnter2D(Collider2D other)
        {
        if (other.gameObject.tag == "chao")
        {
            Drop = true;
            jumping = false;
            
        }
        


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "chao")
        {
            Drop = false;
           
        }
        if (other.gameObject.tag == "Vendedor")
        {
            Animation.SetTrigger("Kick");
            jumping = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "barreira")
        {
            vy = 0;
            
            OnSomeObject = true;
            barrier = true;
        }
        else
        {
            OnSomeObject = false;
            barrier = false;
        }

    }

    void OnCollisionEntry2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tenda")
        {
            Animation.SetBool("Crouch", true);
            crouch = true;
        }
    }

    }
