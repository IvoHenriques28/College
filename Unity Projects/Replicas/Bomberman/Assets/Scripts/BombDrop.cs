using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombDrop : MonoBehaviour
{
    public GameObject bombPrefab;
    
    public int count;
    public int MaxOnScreenBombs;
    private Vector2 position;
    void Start()
    {
        MaxOnScreenBombs = 1;
       
    }

    
    void Update()
    {
        position = new Vector2((int)transform.position.x, (int)transform.position.y );
        count = GameObject.FindGameObjectsWithTag("Bomb").Length;
        if (Input.GetKeyDown(KeyCode.J) && count <MaxOnScreenBombs)
        {
            Instantiate(bombPrefab, position, Quaternion.identity);
            
        }
    }
}
