﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarPlayer : MonoBehaviour
{
    public GameObject player;
    private void Awake()
    {
        foreach (var button in GetComponentsInChildren<HotbarButton>())
        {
            button.OnButtonClicked += ButtonOnButtonClicked;
        }
    }

    private void ButtonOnButtonClicked(int buttonNumber)
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<HotbarButton>().number == buttonNumber)
            {
                child.GetComponent<Image>().color = Color.red;
            }
            else
            {
                child.GetComponent<Image>().color = Color.white;
            }
        }
        player.GetComponent<HunterSpells>().spellIndex = buttonNumber;
    }


}