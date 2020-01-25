using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RegularMovement : MonoBehaviour
{
    public float speed;
    public int Lives;
    public static int maxLives;
    public int timer;
    public TextMeshProUGUI text;

    public AudioSource aud;
    public AudioSource aud2;
    public AudioSource aud3;
    public AudioClip dmg;
    public AudioClip ammo;
    private Animator anim;
    private SpriteRenderer sr;

    public Animator canvas;
    public GameObject animTarget;

    void Start()
    {
        maxLives = 3;
        canvas = animTarget.GetComponent<Animator>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        text.text = "x " + Lives;
        if (Input.GetKey(KeyCode.W))
        {
            
            anim.SetBool("Walking", true);
            transform.Translate(Vector2.right * speed);
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Walking", true);
            transform.Translate(Vector2.down * speed);
           
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Walking", true);
            transform.Translate(Vector2.up * speed);
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Walking", true);
            transform.Translate(Vector2.left * speed);
            
        }
        else
        {
            anim.SetBool("Walking", false);
            
        }

        

        if (Lives == 0)
        {
            SceneManager.LoadScene(3);
        }

        SoundCheck();

    }

    void SoundCheck()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            aud.Play();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            aud.Play();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            aud.Play();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            aud.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            aud.Stop();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            aud.Stop();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            aud.Stop();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            aud.Stop();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ammo" && Shoot.bulletTotal != Shoot.maxBullet)
        {
            aud3.clip = ammo;
            aud3.volume = 0.2f;
            aud3.Play();
            Shoot.bulletTotal = Shoot.maxBullet;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Health" && Lives < maxLives)
        {
            aud2.Play();
            Lives++;
            Destroy(collision.gameObject, 0.1f);
        }
        if(collision.gameObject.tag == "Projectil")
        {
            canvas.SetTrigger("Hurt");
            Lives--;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FatZombie" || collision.gameObject.tag == "FastZombie" && Lives > 0)
        {
            canvas.SetTrigger("Hurt");
            Lives--;
            aud3.clip = dmg;
            aud3.volume = 0.6f;
            aud3.Play();
            
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "FatZombie" || collision.gameObject.tag == "FastZombie" && Lives > 0)
        {
            timer++;
            if(timer % 15 == 0 && timer % 70 != 0)
            {
                sr.enabled = false;
            }
            else
            {
                sr.enabled = true;
            }
            if(timer % 70 == 0)
            {
                Lives--;
                canvas.SetTrigger("Hurt");
                aud3.clip = dmg;
                aud3.volume = 0.6f;
                aud3.Play();
            }

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        timer = 0;
        sr.enabled = true;
    }
}

