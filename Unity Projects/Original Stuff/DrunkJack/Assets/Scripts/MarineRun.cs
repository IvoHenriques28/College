using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarineRun : MonoBehaviour
{
    public float speed = 0.6f;

    public float vy = 0;
    private float JumpForce;
    private float gravity = 0.1f;

    public GameObject panel;
    public GameObject text;
    public GameObject button;

    public GameObject player;
    public SpriteRenderer sr;

    public Animator anim;
    bool jump = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpForce = 3.2f;

        vy -= gravity * Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        transform.position = new Vector3(transform.position.x + speed / 7, transform.position.y, 0);

        if (transform.position.y < -3.45f)
        {
            //transform.position = new Vector2(transform.position.x, -3.6f);
            vy = 0;
            
        }
        if (transform.position.y < -2f)
        {
          
            anim.ResetTrigger("Jump");
        }


        if (player.transform.position.x < transform.position.x)
        {
            speed = 0;
            sr.flipX = true;
            anim.speed = 0;
        }
        else if (player.transform.position.x < transform.position.x)
        {
            sr.flipX = false;
            anim.speed = 1;
            speed = 0.6f;
        }

        if (player.transform.position.y > transform.position.y)
        {
            StartCoroutine(ProcessJump());
            if (jump)
            {
                anim.SetTrigger("Jump");
                vy = JumpForce * Time.fixedDeltaTime;

                if (vy < 0)
                {
                    vy = 0;
                }
            }
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + vy, 0);
        Debug.Log(vy);
    }

    private IEnumerator ProcessJump()
    {
        yield return new WaitForSeconds(0.5f);
        jump = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            panel.SetActive(false);
            button.SetActive(true);
            text.SetActive(true);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
