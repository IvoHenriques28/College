using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public int nextMenu = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, -nextMenu - 0.2f);
        if (Input.GetButtonDown("Vertical"))
        {
            if(Input.GetAxis("Vertical") > 0)
            {
                nextMenu -= 1;
            }
            else
            {
                nextMenu += 1;
            }
        }
        if(nextMenu > 4)
        {
            nextMenu = 1;
        }
        if(nextMenu < 1)
        {
            nextMenu = 4;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GoNextMenu();
        }
    }

    void GoNextMenu()
    {
        switch (nextMenu)
        {
            case 1:
            case 2:
            case 3:
                SceneManager.LoadScene(nextMenu);
                break;

            case 4:
                Application.Quit();
                break;
        }
    }
}
