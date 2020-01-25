using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBumper1 : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            
            collision.rigidbody.AddForce(-collision.contacts[0].normal * 2, ForceMode2D.Impulse);
        }
    }
   
}
