using System.Linq;
using System.IO;
using System.Collections.Generic;

using UnityEngine;

public class Deck : MonoBehaviour
{
    //list with the deck and instances of each players hands
    public List<GameObject> deck;
    
    public List<Hand> hands;

    //when entering the game scene, the deck is instantly shuffled and the hands are distributed
    private void Awake()
    {
        
        
        ShuffleDeck();
    }

 

    void ShuffleDeck()
    {
        int playerNum = 0;
        int i = 1;

        //for each player, grab 10 random cards from the deck list and add them to that player's hand, while removing them from the deck
        while (deck.Count > 0)
        {
            int value = Random.Range(0, deck.Count);

            hands[playerNum].cardsPrefabs.Add(deck[value]);
            deck.RemoveAt(value);

            if ((i % 10).Equals(0))
                playerNum++;

            i++;
        }
    }

}

