using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public BoxCollider2D boundary;
    public GameObject ammoPrefab;
    public GameObject healthPrefab;
    public int ammoAmount;
    public int healthAmount;

    void Start()
    {
        boundary = GetComponent<BoxCollider2D>();
        InstantiateObjects();
       
    }

   
   public void InstantiateObjects()
    {
        Vector2 colliderPos = (Vector2)boundary.transform.position + boundary.offset;
        for(int i = 0; i < ammoAmount; i++)
        {
            Instantiate(ammoPrefab, new Vector3(Random.Range(colliderPos.x - boundary.size.x / 2, colliderPos.x + boundary.size.x / 2), Random.Range(colliderPos.y - boundary.size.y / 2, colliderPos.y + boundary.size.y / 2), -5), Quaternion.identity);
        }
        for (int i = 0; i < healthAmount; i++)
        {
            Instantiate(healthPrefab, new Vector3(Random.Range(colliderPos.x - boundary.size.x / 2, colliderPos.x + boundary.size.x / 2), Random.Range(colliderPos.y - boundary.size.y / 2, colliderPos.y + boundary.size.y / 2), -5), Quaternion.identity);
        }
    }
}
