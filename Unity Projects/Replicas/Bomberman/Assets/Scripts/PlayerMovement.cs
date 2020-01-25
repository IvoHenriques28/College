using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float distance;
    
    void Start()
    {
       
    }
    void Update()
    {
     
       
        
    }
    
    void FixedUpdate()
    {
        
        
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * speed);
        } else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * speed);
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(Vector2.up * speed);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(Vector2.down * speed);
        }
      
    }

}
