using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourHand : MonoBehaviour
{
    GameObject[] CardInHand;
    GameObject[] choosableCards = new GameObject[3];


    public GameObject deck;
    private Deck cardDeck;

    void Start()
    {
        cardDeck = deck.GetComponent<Deck>();
    }

    public void chooseCards()
    {
        for (int i = 0; i < choosableCards.Length; i++)
        {
            choosableCards[i] = cardDeck.GetTopDeck();
        }
    }

    public void TakeCard()
    {

    }
}
