using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoHUD : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        text.text = "Ammo:  " + Shoot.bulletCount + "-" + Shoot.bulletTotal;
    }
}
