using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Camera cam;
    
   
    private void Start()
    {
        
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
        
    }

    void Update()
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);
        transform.Translate(Vector2.right * 0.5f);
        if(screenPoint.x > 1 || screenPoint.x < 0)
        {
            Destroy(gameObject);
        }
        if (screenPoint.y > 1 || screenPoint.y < 0)
        {
            Destroy(gameObject);
        }
     
      
    }

    private void OnTriggerEnter2D(Collider2D cd)
    {
        if(cd.gameObject.tag == "House")
        {
            Destroy(gameObject);
        }
        
    }
}
