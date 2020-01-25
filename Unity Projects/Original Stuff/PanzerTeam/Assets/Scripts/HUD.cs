using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class HUD : MonoBehaviour
{
    public static int points;
    public GameObject player;
    public GameObject boss;
    public GameObject Levelup;
    public TextMeshProUGUI text;
    public bool powerUp1;
    public bool powerUp2;
    public bool powerUp3;
    public bool bossSpawned;

    public AudioSource aus;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        points = 0;
        powerUp1 = false;
        powerUp2 = false;
        powerUp3 = false;
        text = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        text.text = "Points: " + points;
        if(points >= 50 && powerUp1 == false)
        {
            Instantiate(Levelup, player.transform.position, Quaternion.identity);
            aus.Play();
            Shoot.maxBullet = 30;
            powerUp1 = true;
        }

        if(points >= 150 && powerUp2 == false)
        {
            Instantiate(Levelup, player.transform.position, Quaternion.identity);
            aus.Play();
            RegularMovement.maxLives++;
            powerUp2 = true;
        }

        if(points >= 200 && powerUp3 == false)
        {
            Instantiate(Levelup, player.transform.position, Quaternion.identity);
            aus.Play();
            Shoot.maxBullet = 50;
            powerUp3 = true;
        }
        if (points == 250 && bossSpawned == false)
        {
            Instantiate(boss, new Vector3(Random.Range(187, 255), Random.Range(-44, 45), -5), Quaternion.identity);
            bossSpawned = true;
        }
    }
}
