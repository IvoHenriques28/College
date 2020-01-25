using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPurple : MonoBehaviour
{ 
    Rigidbody2D rb;
    public float speed;
    float posX;
    float posY; //a posição de Y vai ser sempre igual 
    public bool SpawnRight = true;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Dependendo do Spawn das personagens , ligar ou desligar o SpawnRight
    void Update()
    {
        if (SpawnRight == true)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
