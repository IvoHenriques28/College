using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public Text text;
    public static int points;
    void Start()
    {
        text = GetComponent<Text>();
    }

    
    void Update()
    {
        text.text = "Points: " + points;
    }
}
