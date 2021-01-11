using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIChange : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Image image;
    public Sprite winningSprite;
    public Sprite losingSprite;
    public GameObject client;
    public TextMeshProUGUI text;

    public AudioClip winning;
    public AudioClip losing;

    private void Start()
    {
        image = GetComponentInChildren<Image>();
    }
    private void Update()
    {
        client = GameObject.FindGameObjectWithTag("Client");
        if(client.GetComponent<HunterClient>().gameStarted == true)
        {
            if (client.GetComponent<HunterClient>().youWon == false)
            {
                image.sprite = losingSprite;
                text.text = "You Lose...";
            }
            else
            {
                image.sprite = winningSprite;
                text.text = "You Win!!!";
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if(text != null)
        {
            if(text.text == "You Win!!!")
            {
                client.GetComponent<AudioSource>().clip = winning;
                client.GetComponent<AudioSource>().Play();
            }
            if (text.text == "You Lose...")
            {
                client.GetComponent<AudioSource>().clip = losing;
                client.GetComponent<AudioSource>().Play();
            }
        }
    }
    public void OptionsMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMenu()
    {
        if(client != null)
        {
            Destroy(client.gameObject);
        }
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

  

    public void SetSound(float soundLevel)
    {
        masterMixer.SetFloat("musicVol", soundLevel);
    }
}

