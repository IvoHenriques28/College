using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWizard : MonoBehaviour
{
    public int health;
    public GameObject player;
    public GameObject spawner;
    public GameObject spell;
    public Animator anim;

    public AudioSource ac;
    public AudioClip fireBall;
    void Start()
    {
        ac = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        InvokeRepeating("Attack", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            anim.SetBool("dead", true);
        }
        transform.LookAt(player.transform.position);
    }

    void Attack()
    {
        anim.Play("attack_short_001");
    }

    public void Destroyed()
    {
        Destroy(gameObject);
    }
    void CastSpell()
    {
        ac.clip = fireBall;
        ac.Play();
        GameObject fireball = Instantiate(spell, spawner.transform.position, transform.rotation);
        fireball.GetComponent<SpellCollision>().CantDmgEnemy = true;
    }

    public void TakeDmg(int dmg)
    {
        health = health - dmg;
    }
}
