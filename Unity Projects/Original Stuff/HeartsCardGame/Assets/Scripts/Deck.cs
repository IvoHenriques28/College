using System.Linq;
using System.IO;
using System.Collections.Generic;

using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> deck;
    
    public List<Hand> hands;

    private void Awake()
    {
        //hands = GameObject.FindGameObjectsWithTag("hands").Select(x => x.GetComponent<Hand>()).ToList();
        
        ShuffleDeck();
    }

 

    void ShuffleDeck()
    {
        int playerNum = 0;
        int i = 1;

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

