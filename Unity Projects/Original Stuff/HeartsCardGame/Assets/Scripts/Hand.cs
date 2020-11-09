using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public enum direction
    {
        horizontal,
        vertical
    }
    

    public List<GameObject> cardsPrefabs;
    public List<GameObject> cardsObjects = new List<GameObject>();
    
    public List<GameObject> playableCards;
    public string searchType;
    public int searchNum;
    public Sprite background;
    private bool isPlayer;
    public GameObject prefab;

    public direction dir;

    void Start()
    {
        playableCards = new List<GameObject>();
        isPlayer = GetComponent<Player>().isHuman;       
        cardsObjects.Sort((x, y) => y.GetComponent<Card>().value.CompareTo(x.GetComponent<Card>().value));
        BuildHand();
       

    }
    public void BuildHand()
    {
        Vector2 cardPosition;

        for (int i = 0; i < cardsPrefabs.Count; i++)
        {

            var gameObj = Instantiate(prefab, Vector3.zero, transform.rotation);
            cardsObjects.Add(gameObj);
            cardPosition = new Vector2(transform.position.x + cardsPrefabs[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x * i, transform.position.y);


            if (dir.Equals(direction.vertical))
            {
                cardPosition = new Vector2(transform.position.x, transform.position.y + cardsPrefabs[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x * i);
            }
            gameObj.transform.position = cardPosition;
            gameObj.transform.parent = transform;
            var card = gameObj.GetComponent<Card>();

            if (isPlayer == true)
            {
                card.type = cardsPrefabs[i].GetComponent<SpriteRenderer>().sprite.name;
                card.Flip(card.type);
            }
            else
            {
                card.type = cardsPrefabs[i].GetComponent<SpriteRenderer>().sprite.name;
                card.Flip("Playing-Cards");
            }
        }

    }
    public void UpdatePlayableCards()
    {
     
        SearchCardTypes(searchType);
        if (playableCards.Count == 0 && searchType != null && isPlayer == true)
        {
            searchType = null;
            SearchCardTypes(searchType);
        }
        if (isPlayer == false && playableCards.Count == 0 && searchType != null)
        {
            searchType = "hearts";
            SearchCardTypes(searchType);
        }



    }

    
    public bool HasCard(string name)
    {
        foreach (var card in cardsPrefabs)
        {

            if (card.name == name) return true;
        }
        return false;
    }

    public void SearchCardTypes(string type)
    {
        
        foreach (var card in cardsObjects)
        {
            if(card.GetComponent<Card>().suit == type && !playableCards.Contains(card))
            {
              
                    playableCards.Add(card);
                
            }
        }
        if(searchType == "hearts")
        {
            if(GameManager.tableCards.Count == 0)
            {
                playableCards.Sort((x, y) => x.GetComponent<Card>().value.CompareTo(y.GetComponent<Card>().value));
            }
            else
            {
                if(GameManager.tableCards[0].suit != "hearts")
                {
                    playableCards.Sort((x, y) => y.GetComponent<Card>().value.CompareTo(x.GetComponent<Card>().value));
                }
                else
                {
                    playableCards.Sort((x, y) => x.GetComponent<Card>().value.CompareTo(y.GetComponent<Card>().value));
                }
            }
           
        }
        else
        {
            playableCards.Sort((x, y) => x.GetComponent<Card>().value.CompareTo(y.GetComponent<Card>().value));
        }
        

     
    }
}
