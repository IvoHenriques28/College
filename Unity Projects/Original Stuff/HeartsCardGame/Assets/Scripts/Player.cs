using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;


public class Player : MonoBehaviour
{
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
            if (GameManager.tableCards.Count < 4)
            {
                if (id != 0)
                {
                    selectedCard.Flip(selectedCard.type);
                    selectedCard.transform.DOMove(target.transform.position, 0.2f);
                    

                }
                if (selectedCard.spr.sprite.name == selectedCard.type)
                {

                    selectedCard.transform.DOMove(target.transform.position, 0.2f);

                }
                hand.cardsObjects.Remove(selectedCard.gameObject);
                hand.playableCards.Remove(selectedCard.gameObject);
                GameManager.tableCards.Add(selectedCard);
            }
            

            StartCoroutine(GameManager.instance.PlayerTurnFinished());
        }
    }
    public void ProcessMyTurnStart()
    {

        if (GameManager.tableCards.Count == 0 && GameManager.playerTurn == id && id != 0)
        {
            if(hand.playableCards.Count == 0)
            {
                hand.searchType = types[Random.Range(0, types.Length)];
            }
            hand.searchType = types[Random.Range(0, types.Length)];
        }
        
        if(GameManager.tableCards.Count > 0)
        {
            hand.searchType = GameManager.tableCards[0].suit;
        }
        hand.UpdatePlayableCards();
        if (isMyTurn && id != 0)
        {
            
            SelectCard();
            PlaySelectedCard();
            isMyTurn = false;
        }
    
    }

    public void ProcessMyTurnEnd()
    {
        hand.playableCards.Clear();
        
    }
    void SelectCard()
    {
        if (isMyTurn == true && id != 0)
        {
            if (hand.searchType == "hearts" && hand.playableCards.Count == 0)
            {
                selectedCard = hand.cardsObjects[0].GetComponent<Card>();               
                
            }
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
            if(card.suit == "hearts")
            {
                score = score + 1;
            }
            if(card.type == "7_of_spades")
            {
                score = score + 10;
            }
        } 
    }
}
