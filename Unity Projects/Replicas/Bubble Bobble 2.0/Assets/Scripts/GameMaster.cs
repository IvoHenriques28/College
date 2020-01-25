using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public int[,] Mapas;
    public MapCreator[] TheMap;
    public int SideFace;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    void Start()
    {
        MapSave(TheMap[0]);
    }

    private void MapSave(MapCreator map)
    {
        Mapas = new int[17, 37];
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 16; y++)
            {
                Mapas[x, y] = map.matrix[x, y];
            }
        }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            SideFace = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            SideFace = 1;
        }
    }

}
