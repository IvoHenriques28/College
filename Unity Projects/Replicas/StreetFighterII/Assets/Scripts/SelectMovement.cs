using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMovement : MonoBehaviour
{
    public float[] xValues;
    public SpriteRenderer portrait;
    public Placeholder empty;
    public Sprite[] characters;
    public CountrySelection[] countries;
    public int currentCountry;
    public int xPosition = 0;
    public float yPosition = 2;
    // Start is called before the first frame update
    void Start()
    {
        portrait = GameObject.FindGameObjectWithTag("Portrait").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(2);
        }
        empty.currentCharacter = currentCountry;
        CheckInputs();
        UpdateCharacterPortrait();
        UpdateCountrySelected();
        transform.position = new Vector2(xValues[xPosition], -yPosition);
    }
    void UpdateCountrySelected()
    {
        if (yPosition == 2)
        {
            currentCountry = xPosition;
        }
        else
        {
            if (xPosition == 0)
            {
                currentCountry = 4;
            }
            else
            {
                currentCountry = 4 + xPosition;
            }
        }

        for(int i = 0; i < countries.Length; i++)
        {
            if(i == currentCountry)
            {
                countries[i].selected = true;
            }
            else
            {
                countries[i].selected = false;
            }
        }
    }

    void UpdateCharacterPortrait()
    {
        if(yPosition == 2)
        {
            portrait.sprite = characters[xPosition];
        }
        else
        {
            if(xPosition == 0)
            {
                portrait.sprite = characters[4];
            }
            else
            {
                portrait.sprite = characters[4 + xPosition];
            }
        }
    }

    void CheckInputs()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                yPosition -= 1.5f;
            }
            else
            {
                yPosition += 1.5f;
            }
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                xPosition += 1;
            }
            else
            {
                xPosition -= 1;
            }
        }

        if(yPosition > 3.5f)
        {
            yPosition = 2;
        }
        if(yPosition < 2)
        {
            yPosition = 3.5f;
        }
        if(xPosition > 3)
        {
            xPosition = 0;
        }
        if(xPosition < 0)
        {
            xPosition = 3;
        }
    }
}
