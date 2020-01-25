using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public GameObject flame;
    public int range;


    void Start()
    {
        StartCoroutine(Explode());
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2f);

        StartCoroutine(SpawnObject(transform.position.x, transform.position.y, 1, 0));
        StartCoroutine(SpawnObject(transform.position.x, transform.position.y, -1, 0));
        StartCoroutine(SpawnObject(transform.position.x, transform.position.y, 0, 1));
        StartCoroutine(SpawnObject(transform.position.x, transform.position.y, 0, -1));

    }
    IEnumerator SpawnObject(float cx, float cy, int dx, int dy)
    {
        Debug.Log("tile");
                
        for (int i = 0; i < range; i++)
        {
            yield return new WaitForSeconds(0.03f);

            Instantiate(flame, new Vector3(cx+dx * i, cy+dy * i, transform.position.z), Quaternion.identity);

            if (i == 0) yield return null;
        }

    }


    
  
}
