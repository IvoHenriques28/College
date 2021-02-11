using System.Collections;
using System.Linq;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //variables such as whose turn it is, which round and turn of the round we are on and what cards are played each round
    public static GameManager instance;
    public static string turnCardType;
    public static int playerTurn = 0;
    public static int round = 1;
    public static int turn = 1;

    public bool IsEndOfTurn;


    public static List<Card> tableCards;
    public Text playerTurnTextField;
    public List<Player> players;
    
    private void Awake()
    {
        //resets turn to 1
        turn = 1;
        
        IsEndOfTurn = false;

        //if it's a new game (round 1), reset all the scores of the players to 0
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

    //plays the 1st card automatically each round (2 of Clubs)
    public void StartGame(GameObject obj)
    {
        
        turnCardType = "2_of_clubs";
        FirstPlay();
        obj.SetActive(false);


    }


    public void FirstPlay()
    {
        //checks which player has the 2 of clubs at the start of the round and plays it automatically
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
    //when a player ends his turn, switch whose turn it is to the next player
    public IEnumerator PlayerTurnFinished()
    {
        yield return new WaitForSeconds(0.2f);
        players[playerTurn].isMyTurn = false;
        playerTurn++;
        if (playerTurn > 3) playerTurn = 0;
        players[playerTurn].isMyTurn = true;
        players[playerTurn].ProcessMyTurnStart();


    }

    void Update()
    {
        playerTurnTextField.text = "Player: " + playerTurn;
        Debug.Log(turn);

      
        //if there's 4 cards on the table, means a turn has been played, so calls the end of turn function
        if (tableCards.Count == 4 && IsEndOfTurn == false)
        {
            StartCoroutine(ProcessEndOfTurn());
            IsEndOfTurn = true;
        }

        //if there has been 10 turns played, means the round has ended and process the players current score and switches to the score display scene
        if(turn > 10)
        {
          

            StartCoroutine(ProcessSceneChange());
        }


    }


    //always keep track what's the winning card on the table
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

    //when a turn ends, give the player that had the biggest card all the cards on the table
    public void ProcessPlayerTurnWon(Player player)
    {
        foreach (var card in tableCards)
        {
            card.transform.DOMove(player.hand.transform.position, 0.2f);
            player.vaza.Add(card);
            card.gameObject.SetActive(false);
        }

    }

    //process each players turn ending 
    public void ProcessPlayersTurnEnd()
    {
        foreach (var player in players)
        {
            player.ProcessMyTurnEnd();
        }
    }
    //reset everyones turn boolean and playableCards list
    public void ResetPlayersTurn()
    {
        foreach (var player in players)
        {
            player.isMyTurn = false;
            player.hand.playableCards.Clear();
        }

    }

    //process each players start of turn
    public void ProcessPlayersTurnStart()
    {
        foreach (var player in players)
        {
            player.ProcessMyTurnStart();
        }
    }

    //when a turn ends, process who won the turn and reset all variables back to starting position for a new turn
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

 
    //when a round is played, switch scenes to the score display scene
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

