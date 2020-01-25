using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public GameObject player;
    
    public float distance;
  
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
      
    }

 
}
