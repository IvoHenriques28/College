using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject player;
    public GameObject client;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        client = GameObject.FindGameObjectWithTag("Client");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.GetComponent<HunterSpells>() != null && startTime <= 0)
        {
            client.GetComponent<HunterClient>().youWon = true;
            client.GetComponent<HunterClient>().Disconnect();
            SceneManager.LoadScene(4);
        }
        if(player.GetComponent<RemoteHunterSpells>() != null && startTime <= 0)
        {
            client.GetComponent<HunterClient>().youWon = false;
            client.GetComponent<HunterClient>().Disconnect();
            SceneManager.LoadScene(4);
        }
        StartCoroutine(SetTime());
    }

    IEnumerator SetTime()
    {
        yield return new WaitForSeconds(0.01f);
        startTime = startTime - 0.01f;
        UpdateTimer();    
    }

    void UpdateTimer()
    {
        string minutes = ((int)startTime / 60).ToString();
        string seconds = ((int)startTime % 60).ToString("00");
        string milliseconds = ((startTime * 1000) % 1000).ToString("000");


        timerText.text = minutes + ":" + seconds + ":" + milliseconds;
    }
}
