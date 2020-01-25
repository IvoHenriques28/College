using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisao : MonoBehaviour
{
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Blocking"))
        {
            Debug.Log("Blocked");
        }
        else
        {
            anim.SetTrigger("Hurting");
        }
        
    }
}
