using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    // Start is called before the first frame update
    public int cols;
    public int rows;
    public static GameObject[,] map;
    public GameObject tile;

    IEnumerator SpawnObject()
    {
        Debug.Log("tile");

        map = new GameObject[cols, rows];
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                map[i, j] = Instantiate(tile, new Vector3(i, -j, transform.position.z), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }

        }
        
    }
    void Start()
    {
        StartCoroutine(SpawnObject());

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
