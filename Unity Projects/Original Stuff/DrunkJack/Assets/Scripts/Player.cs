using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   public float speed = 0.9f;
   
    public float vy = 0;
    private float JumpForce;
    private float gravity = 0.1f;
    bool OnTheGround;
    bool OnSomeObject;
    bool OnSomeBounceObject;
    public Anim anim;
    float GroundLevel;
    public bool collide = false;
    float end = 170;

    private bool crouch = false;

    
    void Start()
    {
        JumpForce = 7f;
    }

   
    void Update()
    {
       

        JumpForce = 6f;
        vy -= gravity * Time.fixedDeltaTime;
        GroundLevel = -4.1f;

        
        
            speed = 0.8f;
        
        if (speed <= 0)
        {
            speed = 0;

        }
        else
        {
            if (Input.GetButton("Fire2") && transform.position.x < end)
            {
                crouch = true;
                speed = 0.3f;
                JumpForce = 3f;
            }
            if (transform.position.y <= GroundLevel)
            {
                vy = 0;
                OnTheGround = true;
            }
            else
            {
                OnTheGround = false;
            }

            if (OnTheGround == true || OnSomeObject == true || OnSomeBounceObject == true)
            {
                if(OnSomeBounceObject == true)
                {
                    vy = JumpForce *2* Time.fixedDeltaTime;
                }
                if (Input.GetButtonDown("Jump") )
                {
                    vy = JumpForce * Time.fixedDeltaTime;
                    
                    

                }
                else if (vy <= 0)
                {
                    vy = 0;
                }
            }
            



            if (anim.Drop == true)
            {
                speed = 0.3f;

            }
          

            transform.position = new Vector3(transform.position.x, transform.position.y + vy, 0);

            
            if (collide == false)
            {
                MoveR();
               
            }
            
            
        }

    }



    private void MoveR()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        transform.position = new Vector3(transform.position.x + speed / 7, transform.position.y, 0);

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "barreira")
        {
           
            OnSomeObject = true;
           
        }

        if (other.gameObject.tag == "Bounce")
        {

            OnSomeBounceObject = true;

        }

        if (other.gameObject.tag == "Immovable")
        {
            
            collide = true;

        }
    }


    

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "barreira")
        {
            
            OnSomeObject = false;
            
        }
        if (other.gameObject.tag == "Bounce")
        {

            OnSomeBounceObject = false;

        }

        if (other.gameObject.tag == "Immovable")
        {

            collide = false;

        }
    }

}
