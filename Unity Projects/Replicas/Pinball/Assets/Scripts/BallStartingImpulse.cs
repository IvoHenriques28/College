using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStartingImpulse : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.x >= 3.5f && transform.position.y <= -5.8f)
            {
                rb.AddForce(transform.up * 20, ForceMode2D.Impulse);
            }
        }
        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);
        
        if (screenPoint.x > 1 || screenPoint.x < 0)
        {
            transform.position = new Vector3(3.6f, -5.9f);
        }
        if (screenPoint.y > 1 || screenPoint.y < 0)
        {
            transform.position = new Vector3(3.6f, -5.9f);
        }
    }
}
