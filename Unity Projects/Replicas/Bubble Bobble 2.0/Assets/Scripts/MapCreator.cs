using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public GameObject[] blocos;
    public int roomSize;
    public int[,] matrix;

    public MapCreator()
    {
        matrix = new int[16, 16];
    }
    
    void Awake()
    {
        roomSize = 16;
        InitRoom();
        Paredes();
          for (int x = 0; x < roomSize; x++)
        {
            for (int y = 0; y < roomSize; y++)
            {

                Instanciate(x, y, matrix[x, y]);
            }
        }
    }
    void InitRoom()
    {
        for (int y = 0; y < roomSize; y++)
        {
            for (int x = 0; x < roomSize; x++)
            {
                MudarCelula(x, y, 0);
            }
        }
      
    }
    void MudarCelula(int x, int y, int value)
    {

        matrix[x, y] = value;
    }

    void Paredes()
    {
        for (int x = 0; x < roomSize; x++)
        {
            for (int y = 0; y < roomSize; y++)
            {
                if (matrix[x, y] != 2)
                {
                 
                    if (x <= 1 && y >=1 && y <= roomSize -3)
                    {
                        matrix[x, y] = 1;
                    }
                    if (x >= roomSize - 2 && y >=1 && y <= roomSize - 3)
                    {
                        matrix[x, y] = 1;
                    }
                    if (y == 1)
                    {
                        matrix[x, y] = 1;
                    }
                    if (y == roomSize - 1 && x <=7 && x>= 10)
                    {
                        matrix[x, y] = 1;
                    }
                    if (y == 4 || y == 7 || y == 10)
                    {
                        matrix[x, y] = 1;

                    }
                    if (x > 3 && x < 7 && y > 1 && y < roomSize - 1)
                    {
                        matrix[x, y] = 0;
                    }
                    if (x > 9 && x < 13 && y > 1 && y < roomSize - 1)
                    {
                        matrix[x, y] = 0;
                    }
                    if (x <= 7 && y == roomSize - 3)
                    {
                        matrix[x, y] = 1;
                    }
                    if (x >= 9 && y == roomSize - 3)
                    {
                        matrix[x, y] = 1;
                    }

                }
            }
        }
    }
    void Instanciate(int x, int y, int value)
    {
        if (value == 1)
        {
            Instantiate(blocos[0], new Vector2(x, y), Quaternion.identity);
        }
    }
}
