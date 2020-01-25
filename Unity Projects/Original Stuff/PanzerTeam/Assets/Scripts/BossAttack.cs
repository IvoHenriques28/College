using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BossAttack : MonoBehaviour
{
    public GameObject projectil;
    public AudioSource ads;
    void Start()
    {
        
        InvokeRepeating("Shoot", 0f, 5f);
    }

    public void Shoot()
    {
        Instantiate(projectil, new Vector3(transform.position.x, transform.position.y, -5), transform.rotation);
        ads.Play();
    }
}
