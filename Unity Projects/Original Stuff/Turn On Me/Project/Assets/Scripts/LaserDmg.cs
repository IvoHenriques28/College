using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDmg : MonoBehaviour
{
    public int mobDMG;
    public int playerDMG;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        StartCoroutine(DealDmg(other));
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(DealDmg(other));
    }

    IEnumerator DealDmg(Collider other)
    {
        yield return new WaitForSeconds(0.5f);
        if (other.tag == "Player")
        {
            if (other.GetComponent<HunterSpells>() == null)
            {
                other.GetComponent<RemoteHunterSpells>().TakeDmg(playerDMG);
            }
            else
            {
                other.GetComponent<HunterSpells>().TakeDmg(playerDMG);
            }
        }
        if (other.tag == "Enemy")
        {
            other.GetComponent<FollowPlayer>().TakeDmg(mobDMG);
        }
    }
}
