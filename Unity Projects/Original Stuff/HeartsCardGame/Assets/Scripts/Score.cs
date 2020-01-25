using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int id;
    public int score1;
    public int score2;
    public int score3;
    public int score4;
    public Text text;
    void Awake()
    { 
        if(GameManager.round == 1)
        {
            score1 = 0;
            score2 = 0;
            score3 = 0;
            score4 = 0;
        }
               
    }
    private void Start()
    {
        score1 = score1 + PlayerPrefs.GetInt("score" + 0, 0);
        score2 = score2 + PlayerPrefs.GetInt("score" + 1, 0);
        score3 = score3 + PlayerPrefs.GetInt("score" + 2, 0);
        score4 = score4 + PlayerPrefs.GetInt("score" + 3, 0);
        text = GetComponent<Text>();
        if (id == 0)
        {
            text.text = "Player: " + score1;
        }
        if (id == 1)
        {
            text.text = "AI 1: " + score2;
        }
        if (id == 2)
        {
            text.text = "AI 2: " + score3;
        }
        if (id == 3)
        {
            text.text = "AI 3: " + score4;
        }
    }


    private void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("score" + 0));
        Debug.Log(PlayerPrefs.GetInt("score" + 1));
        Debug.Log(PlayerPrefs.GetInt("score" + 2));
        Debug.Log(PlayerPrefs.GetInt("score" + 3));

    }





}
