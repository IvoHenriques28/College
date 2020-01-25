using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotation : MonoBehaviour
{
    public float speed;
    public GameObject player;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed, -5);
        Destroy(gameObject, 2f);
        
    }
    
   
 
}
