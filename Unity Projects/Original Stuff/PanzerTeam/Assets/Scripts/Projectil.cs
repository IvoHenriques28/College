using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    public float speed;
    public Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        transform.Translate(Vector2.right * speed);
    }
}
