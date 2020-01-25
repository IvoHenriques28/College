using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.IO;

public class Card : MonoBehaviour
{
    public int value;
    public string suit;

    public string type;
    public Player player;
    
    public string spriteFolder;

    public SpriteRenderer spr;
    
    void Start()
    {
        player = transform.parent.GetComponent<Player>();
        value = int.Parse(type.Split('_')[0]);
        suit = type.Split('_')[2];

        DOTween.Init();
    }

    public void Flip(string spriteName)
    {
     
                spr.sprite = Resources.Load<Sprite>(Path.Combine(spriteFolder, spriteName));
        gameObject.AddComponent<BoxCollider2D>();
    }
    /*
    public void PlayCard()
    {
        player = transform.parent.GetComponent<Player>();
        if(GameManager.tableCards.Count < 4)
        {
            if (player.id != 0)
            {
                Flip(type);
                transform.DOMove(player.target.transform.position, 0.2f);

            }
            if (spr.sprite.name == type)
            {

                transform.DOMove(player.target.transform.position, 0.2f);

            }
            player.hand.cardsObjects.Remove(gameObject);
            player.hand.playableCards.Remove(gameObject);
            GameManager.tableCards.Add(this);
        }
      

        GameManager.instance.PlayerTurnFinished();
    }
    */
    private void OnMouseDown()
    {
        
        
        if (!player.isMyTurn) return;
        if (player.hand.searchType == null)
        {
            player.hand.searchType = suit;
        }
        if (player.id == 0 && suit == player.hand.searchType)
        {
            player.selectedCard = this;
            player.PlaySelectedCard();
            
        }
     
       

        
    }
}
