using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;


public class Player : MonoBehaviour
{

    //variables such as if the player is human or AI, his ID, hand, score, cards he won (vaza) and the card he selected to play
    public string[] types = { "hearts", "clubs", "spades", "diamonds" };

    public bool isHuman;
    public int id;
    public Transform target;
    public bool isMyTurn;
    public List<Card> vaza;
    public int score;
    public Hand hand;
    public Card selectedCard;
    private void Awake()
    {
        hand = GetComponent<Hand>();
        
        isMyTurn = false;
    }



    void Start()
    {
        selectedCard = null;
        score = 0;


    }
   public void PlaySelectedCard()
    {
        if (selectedCard == null) { Debug.LogError("Player has not selected a card"); return; }
        else
        {
            //if the turn hasn't ended
            if (GameManager.tableCards.Count < 4)
            {
                //if it's an AI player, flip the sprite of the card and move it to the center of the table using DOTween
                if (id != 0)
                {
                    selectedCard.Flip(selectedCard.type);
                    selectedCard.transform.DOMove(target.transform.position, 0.2f);
                    

                }
                //if it's the human player, simply move the card to the center of the table
                if (selectedCard.spr.sprite.name == selectedCard.type)
                {

                    selectedCard.transform.DOMove(target.transform.position, 0.2f);

                }
                //remove the card from the hand lists and add them to the tableCards list
                hand.cardsObjects.Remove(selectedCard.gameObject);
                hand.playableCards.Remove(selectedCard.gameObject);
                GameManager.tableCards.Add(selectedCard);
            }
            
            //after card is played, process the end of turn in the GameManager
            StartCoroutine(GameManager.instance.PlayerTurnFinished());
        }
    }
    public void ProcessMyTurnStart()
    {
        //if the player is AI and is the 1st player to play a card, select a random suit to play
        if (GameManager.tableCards.Count == 0 && GameManager.playerTurn == id && id != 0)
        {
            hand.searchType = types[Random.Range(0, types.Length)];
            //if the AI has no playable cards of that suit, reselect the suit
            if (hand.playableCards.Count == 0)
            {
                hand.searchType = types[Random.Range(0, types.Length)];
            }
            
        }
        //if the first card has been played, update the playable cards to that suit
        if(GameManager.tableCards.Count > 0)
        {
            hand.searchType = GameManager.tableCards[0].suit;
        }
        hand.UpdatePlayableCards();

        //if it's the AIs turn, select the card and play it
        if (isMyTurn && id != 0)
        {
            
            SelectCard();
            PlaySelectedCard();
            isMyTurn = false;
        }
    
    }

    //clear all playable cards
    public void ProcessMyTurnEnd()
    {
        hand.playableCards.Clear();
        
    }

    //AI Card selection
    void SelectCard()
    {
        if (isMyTurn == true && id != 0)
        {
            //if the suit of the 1st played is hearts and the AI doesn't have them, he plays the highest value card out of all his hand
            if (hand.searchType == "hearts" && hand.playableCards.Count == 0)
            {
                selectedCard = hand.cardsObjects[0].GetComponent<Card>();               
                
            }
            //else, he plays the first card in his list of playable cards
            else
            {
                selectedCard = hand.playableCards[0].GetComponent<Card>();
            }

        }
    }

    
    public void ChangeScore()
    {
        foreach(var card in vaza)
        {
            //for each heart card the player won, it adds 1 point to his score
            if(card.suit == "hearts")
            {
                score = score + 1;
            }
            //the player that picks up the queen of spades gets added 10 points to his score
            if(card.type == "7_of_spades")
            {
                score = score + 10;
            }
        } 
    }
}
