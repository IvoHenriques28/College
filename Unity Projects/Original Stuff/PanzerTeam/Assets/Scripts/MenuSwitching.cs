using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSwitching : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        
    }

    public void RageQuit()
    {
        Application.Quit();
    }
}
