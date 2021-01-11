using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //regular walking speed
    public bool isWalking; //check whether the player is walking or not

    public Animator anim;
    public GameObject client;



    //getting our components, setting the running and crouching speeds in relation to the regular walking speed, setting the bools 
    private void Start()
    {
        client = GameObject.FindGameObjectWithTag("Client");
        anim = GetComponent<Animator>();
    }

    //constantly checking our player's movement
    private void Update()
    {
        SendCoordinates();
        MovementKeys();
    }
     void SendCoordinates()
    {
        client.GetComponent<HunterClient>().SendCoordinatePatcket(transform.position, transform.rotation.eulerAngles, Input.GetAxisRaw("Vertical"));
    }

    //regular movement + sprinting movement + crouching movement
    void MovementKeys()
    {
        //getting the Input on our Horizontal and Vertical Axis
        float z = Input.GetAxisRaw("Vertical");
        anim.SetInteger("InputVertical", (int)z);

        //if the player is walking and not crouching, do a simple translate depending on the Axis values and multiply it by the regular movement speed
   
            if(z > 0)
            {
                transform.Translate(Vector3.forward * speed * Time.unscaledDeltaTime);
            }
            if(z < 0)
            {
                transform.Translate(Vector3.forward * -speed * Time.unscaledDeltaTime);
            }
    }



}
