using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HotbarButton : MonoBehaviour
{
    public event Action<int> OnButtonClicked;

    public KeyCode keyCode;
    private TMP_Text text;
    public int number;


    private void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
        text.SetText(number.ToString());
        GetComponent<Button>().onClick.AddListener(ClickEvent);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            ClickEvent();
        }
    }
    void ClickEvent()
    {
        OnButtonClicked?.Invoke(number);
    }
}
