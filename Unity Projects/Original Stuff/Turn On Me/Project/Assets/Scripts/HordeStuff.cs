using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeStuff : MonoBehaviour
{
    public int children;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {

            children++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(children == 0)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateChildren()
    {
        children--;
    }
}
