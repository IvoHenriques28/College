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
    
    //variables such as the cards in hand, what suit is playable and what cards the player can play. Also AI settings such as if it's the player or the AI
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
        //sees if the player is human or AI, sorts the cards by value and builds it
        playableCards = new List<GameObject>();
        isPlayer = GetComponent<Player>().isHuman;       
        cardsObjects.Sort((x, y) => y.GetComponent<Card>().value.CompareTo(x.GetComponent<Card>().value));
        BuildHand();
       

    }
    public void BuildHand()
    {
        Vector2 cardPosition;

        //spawns the card gameobjects on the screen, depending on if it's the player or AI and which sprite to use, etc
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
        //search cards in hand matching the searchType
        SearchCardTypes(searchType);

        //if it's the player's turn and there is no specific searchType (if he's the first player or has no cards from the same suit as the 1st played one)
        //allow the player to play any card
        if (playableCards.Count == 0 && searchType != null && isPlayer == true)
        {
            searchType = null;
            SearchCardTypes(searchType);
        }
        //if it's an AI turn and there is no specific searchType when he ISN'T the 1st player of the turn (has no cards from the same suit as the 1st played one)
        //make it so that the player plays his highest value hearts card if possible (since he doesn't want to get them and is 100% sure to get rid of one)
        if (isPlayer == false && playableCards.Count == 0 && searchType != null)
        {
            searchType = "hearts";
            SearchCardTypes(searchType);
        }



    }

    //function called in the GameManager to see who has the 2 of clubs
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
        //for each card in the player's hand, if it's playable, add them to the playableCards list
        foreach (var card in cardsObjects)
        {
            if(card.GetComponent<Card>().suit == type && !playableCards.Contains(card))
            {
              
                    playableCards.Add(card);
                
            }
        }

        //if the search type is hearts, sort the cards depending on certain aspects (for the AI, since he always plays the first card on the playable cards list)
        if(searchType == "hearts")
        {
            //if it's the first card to be played, sort it by lowest to highest value so the AI plays the smallest hearts card it has
            if(GameManager.tableCards.Count == 0)
            {
                playableCards.Sort((x, y) => x.GetComponent<Card>().value.CompareTo(y.GetComponent<Card>().value));
            }
            else
            {
                //if the first card played wasn't hearts, sort it by highest to lowest value so the 1st card on the list is the highest hearts card the AI has
                if(GameManager.tableCards[0].suit != "hearts")
                {
                    playableCards.Sort((x, y) => y.GetComponent<Card>().value.CompareTo(x.GetComponent<Card>().value));
                }
                //if the first card played WAS hearts, sort it by lowest to highest value
                else
                {
                    playableCards.Sort((x, y) => x.GetComponent<Card>().value.CompareTo(y.GetComponent<Card>().value));
                }
            }
           
        }
        //if the search type isn't hearts, sort the cards by lowest to highest value
        else
        {
            playableCards.Sort((x, y) => x.GetComponent<Card>().value.CompareTo(y.GetComponent<Card>().value));
        }
        

     
    }
}
