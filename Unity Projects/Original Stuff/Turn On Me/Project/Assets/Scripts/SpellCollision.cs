using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    public bool CanDmgPlayer;
    public int dmg;
    public int speed;
    public bool CantDmgEnemy;

    public bool backwardsMoving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(backwardsMoving == true)
        {
            transform.Translate(Vector3.back * speed * Time.unscaledDeltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.unscaledDeltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && CantDmgEnemy == false)
        {
            if(other.GetComponent<FollowPlayer>() == null)
            {
                other.GetComponent<RangedWizard>().TakeDmg(dmg);
            }
            else
            {
                other.GetComponent<FollowPlayer>().TakeDmg(dmg);
            }
            Debug.Log("Hit");
            Destroy(gameObject);
        }
        if(other.tag == "Player"  && CanDmgPlayer == true)
        {
            if(other.GetComponent<RemoteHunterSpells>() == null)
            {
                if(other.GetComponent<HunterSpells>().deflectable == true)
                {
                    backwardsMoving = true;
                }
                else
                {
                    other.GetComponent<HunterSpells>().TakeDmg(dmg);
                    Destroy(gameObject);
                }
            }
            else if(other.GetComponent<HunterSpells>() == null)
            {
                if(other.GetComponent<RemoteHunterSpells>().deflectable == true)
                {
                    backwardsMoving = true;
                }
                else
                {
                    other.GetComponent<RemoteHunterSpells>().TakeDmg(dmg);
                    Destroy(gameObject);
                }
            }
        }
        if(tag == "Meteor")
        {
            Destroy(gameObject);
        }
    }

}
