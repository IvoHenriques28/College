using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused;


    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
           
                PauseGame();
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            UnPauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
       
    }

    private void UnPauseGame()
    {
        Time.timeScale = 1;
        isPaused = false;
      
    }
}
