using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent nav;

    public Animator anim;

    private AudioSource ac;
    public AudioClip death;

    float distance;
    public float distance2;
    public int dmg;
    public int health;
    public bool dead;
    void Start()
    {
        ac = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
   
        if(nav == null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 10f * Time.deltaTime);
            transform.LookAt(player.transform.position);
        }
        else
        {
            nav.SetDestination(player.transform.position);
        }

        distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance <= distance2)
        {
            StartCoroutine(Attack());
        }
        else
        {
            StopCoroutine(Attack());
        }

        if (health <= 0 && dead == false)
        {
            ac.clip = death;
            ac.Play();
            dead = true;
            nav.isStopped = true;
            anim.SetBool("dead", true);
        }
    }

    public void Die()
    {
        transform.parent.GetComponent<HordeStuff>().UpdateChildren();
        Destroy(gameObject);
    }

    IEnumerator Attack()
    {  
        anim.SetBool("attack01", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("attack01", false);
    }

    public void TakeDmg(int dmg)
    {
        health = health - dmg;
    }
    public void DealDmg()
    {
        if(distance <= distance2)
        {
           if(player.GetComponent<HunterSpells>() == null)
            {
                player.GetComponent<RemoteHunterSpells>().TakeDmg(dmg);
            }
            else
            {
                player.GetComponent<HunterSpells>().TakeDmg(dmg);
            }
        }
    }
}
