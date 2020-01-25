using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationApplication : MonoBehaviour
{
    public KeyCode ads;
    public bool leftKeyPressed;
    public bool rightKeyPressed;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(ads))
        {
            if(ads == KeyCode.Z )
            {
                rb.AddTorque(200f);
                leftKeyPressed = true;
            }
            if(ads == KeyCode.M )
            {
                rb.AddTorque(-200f);
                rightKeyPressed = true;
            }
        }
    }
}
