using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav_FollowPlayer : MonoBehaviour
{
    private Transform myTarget;
    // Start is called before the first frame update
    void Start()
    {

        myTarget = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
     
        GetComponent<NavMeshAgent>().SetDestination(myTarget.position);

        

    }
}
