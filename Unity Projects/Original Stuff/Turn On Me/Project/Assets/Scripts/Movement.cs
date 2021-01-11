using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed; //regular walking speed
    public float runningSpeed; //running speed
    public bool isWalking; //check whether the player is walking or not
    public GameObject staff;
    

    public CapsuleCollider playerCapsule;


    //set the timer to 0 and say the player isn't buffed
    private void Awake()
    {

    }


    //getting our components, setting the running and crouching speeds in relation to the regular walking speed, setting the bools 
    private void Start()
    {
        
        runningSpeed = 2 * speed;
        isWalking = true;
       
    }

    //constantly checking our player's movement
    private void Update()
    {
        MovementKeys();
    }

  

    //regular movement + sprinting movement + crouching movement
    void MovementKeys()
    {
        //getting the Input on our Horizontal and Vertical Axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        //if the player is sprinting or not sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isWalking = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isWalking = true;
        }

        //if the player is walking and not crouching, do a simple translate depending on the Axis values and multiply it by the regular movement speed
        if(isWalking == true)
        {
            if(z > 0)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if(z < 0)
            {
                transform.Translate(Vector3.forward * -speed * Time.deltaTime);
            }
            if (x > 0)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (x < 0)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

        }
        //if the player is running and not crouching, do a simple translate depending on the Axis values and multiply it by the running speed
        if (isWalking == false)
        {
            if(z > 0)
            {
                transform.Translate(Vector3.forward * runningSpeed * Time.deltaTime);
            }
            if (z < 0)
            {
                transform.Translate(Vector3.forward * -runningSpeed * Time.deltaTime);
            }
            if (x > 0)
            {
                transform.Translate(Vector3.right * runningSpeed * Time.deltaTime);
            }
            if (x < 0)
            {
                transform.Translate(Vector3.left * runningSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.Translate(Vector3.down * runningSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * runningSpeed * Time.deltaTime);
            }

        }
       


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCapsule)
        {
            staff.GetComponent<SpellCasting>().canSummon = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == playerCapsule)
        {
            staff.GetComponent<SpellCasting>().canSummon = true;
        }
    }
}
