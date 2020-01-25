using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explodeCenterPrfb;
    public GameObject explodeHBridgePrfb;
    public GameObject explodeVBridgePrfb;
    public GameObject explodeTopEndPrfb;
    public GameObject explodeRightEndPrfb;
    public GameObject explodeLeftEndPrfb;
    public GameObject explodeBottomEndPrfb;
  

    public int explosionPower;

   
 
    void Start()
    {
       
        Instantiate(explodeCenterPrfb, transform.position, Quaternion.identity);
        
        CheckSides();
        
    }
    void CheckSides()
    {
        for (int i = 1; i <= explosionPower; i++)
        {
            if (MapCreator.matrix[(int)transform.position.x, (int)transform.position.y + i] == 0)
            {
                if (i < explosionPower)
                {
                   var obj = Instantiate(explodeVBridgePrfb);
                    obj.transform.position = new Vector2(transform.position.x, transform.position.y + i);
                }
                else if (i == explosionPower)
                {
                    var obj =Instantiate(explodeTopEndPrfb);
                    obj.transform.position = new Vector2(transform.position.x, transform.position.y + i);
                }
            }
            if (MapCreator.matrix[(int)transform.position.x, (int)transform.position.y - i] == 0)
            {
                if (i < explosionPower)
                {
                    var obj = Instantiate(explodeVBridgePrfb);
                    obj.transform.position = new Vector2(transform.position.x, transform.position.y - i);
                }
                else if (i == explosionPower)
                {
                    var obj =Instantiate(explodeBottomEndPrfb);
                    obj.transform.position = new Vector2(transform.position.x, transform.position.y - i);
                }
            }
            if (MapCreator.matrix[(int)transform.position.x + i, (int)transform.position.y] == 0)
            {
                if (i < explosionPower)
                {
                    var obj = Instantiate(explodeHBridgePrfb);
                    obj.transform.position = new Vector2(transform.position.x + i, transform.position.y);
                }
                else if (i == explosionPower)
                {
                   var obj = Instantiate(explodeRightEndPrfb);
                    obj.transform.position = new Vector2(transform.position.x + i, transform.position.y);
                }
            }
            if (MapCreator.matrix[(int)transform.position.x - i, (int)transform.position.y] == 0)
            {
                if (i < explosionPower)
                {
                    var obj = Instantiate(explodeHBridgePrfb);
                    obj.transform.position = new Vector2(transform.position.x - i, transform.position.y);
                }
                else if (i == explosionPower)
                {
                    var obj =Instantiate(explodeLeftEndPrfb);
                    obj.transform.position = new Vector2(transform.position.x - i, transform.position.y);
                }
            }
            if(MapCreator.matrix[(int)transform.position.x + i, (int)transform.position.y] == 2)
            {
                MapCreator.matrix[(int)transform.position.x + i, (int)transform.position.y] = 0;
            }
            if (MapCreator.matrix[(int)transform.position.x , (int)transform.position.y - i] == 2)
            {
                MapCreator.matrix[(int)transform.position.x , (int)transform.position.y - i] = 0;
            }
            if (MapCreator.matrix[(int)transform.position.x - i, (int)transform.position.y] == 2)
            {
                MapCreator.matrix[(int)transform.position.x - i, (int)transform.position.y] = 0;
            }
            if (MapCreator.matrix[(int)transform.position.x , (int)transform.position.y + i] == 2)
            {
                MapCreator.matrix[(int)transform.position.x , (int)transform.position.y + i] = 0;
            }
        }
    }
  
}
