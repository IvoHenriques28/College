using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBumperHit1 : MonoBehaviour
{

    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            anim.SetTrigger("Hit");
            collision.rigidbody.AddForce(-collision.contacts[0].normal * 8, ForceMode2D.Impulse);
        }
      
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            anim.ResetTrigger("Hit");
        }
    }
}
