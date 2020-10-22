using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountrySelection : MonoBehaviour
{
    public Sprite[] countryHighlight;

    public bool selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selected == true)
        {
            GetComponent<SpriteRenderer>().sprite = countryHighlight[1];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = countryHighlight[0];
        }
    }
}
