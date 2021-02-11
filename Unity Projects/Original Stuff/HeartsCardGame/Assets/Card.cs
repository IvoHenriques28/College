using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.IO;

public class Card : MonoBehaviour
{
    //card information, including value, suit and which player owns it
    public int value;
    public string suit;

    public string type;
    public Player player;
    
    public string spriteFolder;

    public SpriteRenderer spr;
    
    //defines the parent object (the player that owns the card) as well as its value and suit depending on the type variable
    //initialize the DOTween library
    void Start()
    {
        player = transform.parent.GetComponent<Player>();
        value = int.Parse(type.Split('_')[0]);
        suit = type.Split('_')[2];

        DOTween.Init();
    }

    //Function that flips the cards of the AI players when they are played so the player can see them
    public void Flip(string spriteName)
    {
     
                spr.sprite = Resources.Load<Sprite>(Path.Combine(spriteFolder, spriteName));
        gameObject.AddComponent<BoxCollider2D>();
    }

    //when the player clicks on a card
    private void OnMouseDown()
    {
        
        //checks if it's his turn
        if (!player.isMyTurn) return;

        //checks if his card is the 1st to be played of the round
        if (player.hand.searchType == null)
        {
            player.hand.searchType = suit;
        }

        //if not, if the card pressed is from the player's hand and not the AI and if the suit of the card is allowed to be played
        //calls the play card function from the player
        if (player.id == 0 && suit == player.hand.searchType)
        {
            player.selectedCard = this;
            player.PlaySelectedCard();
            
        }
     
       

        
    }
}
