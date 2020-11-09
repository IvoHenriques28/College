using System.Collections;
using System.Linq;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static string turnCardType;
    public static int playerTurn = 0;
    public static int round = 1;
    public static int turn = 1;

    public bool IsEndOfTurn;


    public static List<Card> tableCards;
    public Text playerTurnTextField;
    public List<Player> players;
    // Start is called before the first frame update
    private void Awake()
    {
        turn = 1;
        
        IsEndOfTurn = false;
        if(round == 1)
        {
            PlayerPrefs.SetInt("score" + 0, 0);
            PlayerPrefs.SetInt("score" + 1, 0);
            PlayerPrefs.SetInt("score" + 2, 0);
            PlayerPrefs.SetInt("score" + 3, 0);
        }
   
        instance = this;
        tableCards = new List<Card>();
    }


    public void StartGame(GameObject obj)
    {
        
        turnCardType = "2_of_clubs";
        FirstPlay();
        obj.SetActive(false);


    }


    public void FirstPlay()
    {
        
        for (int i = 0; i < players.Count; i++)
        {
            var has2ofClubs = players[i].hand.HasCard(turnCardType);
            players[i].hand.searchType = "clubs";
            
            if (has2ofClubs && turn == 1)
            {
                
                players[i].isMyTurn = true;
                playerTurn = i;
                var card = players[i].hand.cardsObjects.Find(x => x.GetComponent<Card>().type.Equals(turnCardType));
                players[i].selectedCard = card.GetComponent<Card>();
                players[i].PlaySelectedCard();
                break;

            }

        }
    }
    public IEnumerator PlayerTurnFinished()
    {
        yield return new WaitForSeconds(0.2f);
        players[playerTurn].isMyTurn = false;
        playerTurn++;
        if (playerTurn > 3) playerTurn = 0;
        players[playerTurn].isMyTurn = true;
        players[playerTurn].ProcessMyTurnStart();


    }

    // Update is called once per frame
    void Update()
    {
        playerTurnTextField.text = "Player: " + playerTurn;
        Debug.Log(turn);
        if (Input.GetKeyDown(KeyCode.P))
        {
            FirstPlay();
        }
      

        if (tableCards.Count == 4 && IsEndOfTurn == false)
        {
            StartCoroutine(ProcessEndOfTurn());
            IsEndOfTurn = true;
        }
        if(turn > 10)
        {
          

            StartCoroutine(ProcessSceneChange());
        }


    }

    public void PlayGame()
    {

    }

    public Card GetBiggestCardOnTable()
    {
        
        int maxPoint = 0;
        Card maxCard = null;

        foreach (var card in tableCards)
        {
            if (card.value > maxPoint && card.suit == tableCards[0].suit)
            {
                maxPoint = card.value;
                maxCard = card;
            }
        }
      

        return maxCard;
    }

    public void ProcessPlayerTurnWon(Player player)
    {
        foreach (var card in tableCards)
        {
            card.transform.DOMove(player.hand.transform.position, 0.2f);
            player.vaza.Add(card);
            card.gameObject.SetActive(false);
        }

    }
    public void ProcessPlayersTurnEnd()
    {
        foreach (var player in players)
        {
            player.ProcessMyTurnEnd();
        }
    }
    public void ResetPlayersTurn()
    {
        foreach (var player in players)
        {
            player.isMyTurn = false;
            player.hand.playableCards.Clear();
        }

    }
    public void ProcessPlayersTurnStart()
    {
        foreach (var player in players)
        {
            player.ProcessMyTurnStart();
        }
    }
    public IEnumerator ProcessEndOfTurn()
    {
        
        yield return new WaitForSeconds(1);
     
        var playerWon = GetBiggestCardOnTable().player;
        ProcessPlayerTurnWon(playerWon);
        IsEndOfTurn = false;
        turn++;
        tableCards.Clear();
        ResetPlayersTurn();
        playerWon.isMyTurn = true;
        players.ForEach(x => x.hand.searchType = null);
        playerTurn = playerWon.id;
        playerWon.ProcessMyTurnStart();
        
    }

 

    public IEnumerator ProcessSceneChange()
    {
        yield return new WaitForSeconds(3);
        foreach (var player in players)
        {
            player.ChangeScore();
            PlayerPrefs.SetInt("score" + player.id, PlayerPrefs.GetInt("score" + player.id) + player.score);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

