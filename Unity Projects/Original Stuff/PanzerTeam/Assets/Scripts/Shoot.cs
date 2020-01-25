using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource aud;
    public AudioSource aud2;
    public static int bulletCount;
    public static int bulletTotal;
    public static int maxBullet;

    private void Start()
    {
        
        bulletCount = 10;
        maxBullet = 20;
        bulletTotal = maxBullet;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && bulletCount > 0)
        {
            var exp = GetComponent<ParticleSystem>();
            Instantiate(bullet, new Vector3(transform.position.x , transform.position.y, transform.position.z), transform.rotation);
            bulletCount--;
            aud.Play();
            exp.Play();
        }
        if (Input.GetKeyDown(KeyCode.R) && bulletTotal > 0)
        {
            aud2.Play();
            bulletCount = 10;
            bulletTotal = bulletTotal - 10;
        }
        if(bulletTotal > maxBullet)
        {
            bulletTotal = maxBullet;
        }
    }
}
