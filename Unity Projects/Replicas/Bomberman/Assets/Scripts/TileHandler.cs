using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHandler : MonoBehaviour
{
    
    public int x;
    public int y;
    public Sprite[] sprites;

    private SpriteRenderer sr;
    private Collider2D co2;

    public static int type;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        co2 = GetComponent<Collider2D>();
    }

    
    void Update()
    {
        type = MapCreator.matrix[x, y];

        sr.sprite = sprites[type];

        switch (type)
        {
            case 0:  co2.enabled = false;break;
            case 1:  co2.enabled = true; break;
            case 2: co2.enabled = true; break;
            case 3: co2.enabled = true; break;
        }
    }
}
