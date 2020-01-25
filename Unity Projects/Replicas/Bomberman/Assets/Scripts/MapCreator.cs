using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public GameObject tile;
    
    public static int[,] matrix;

    public MapCreator()
    {
        matrix = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 2, 0, 0, 2, 2, 2, 0, 0, 1, 1},
            {1, 0, 3, 2, 3, 2, 3, 0, 3, 2, 3, 0, 1, 1},
            {1, 2, 2, 2, 2, 0, 2, 2, 2, 0, 0, 2, 1, 1},
            {1, 2, 3, 2, 3, 2, 3, 0, 3, 2, 3, 2, 1, 1},
            {1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 1, 1},
            {1, 2, 3, 2, 3, 0, 3, 2, 3, 2, 3, 2, 1, 1},
            {1, 0, 2, 0, 2, 2, 2, 2, 0, 2, 0, 2, 1, 1},
            {1, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 1, 1},
            {1, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 1, 1},
            {1, 2, 3, 2, 3, 0, 3, 2, 3, 2, 3, 0, 1, 1},
            {1, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 1, 1},
            {1, 0, 3, 2, 3, 0, 3, 2, 3, 0, 3, 0, 1, 1},
            {1, 0, 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, 1, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
            
       
        };
    }
    private void Awake()
    {
        
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 14; y++)
            {

                Instanciate(x, y);
            }
        }
    }


    void Instanciate(int x, int y)
    {
     
           var refe = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
            refe.GetComponent<TileHandler>().x = x;
            refe.GetComponent<TileHandler>().y = y;
        
 
    }
}
