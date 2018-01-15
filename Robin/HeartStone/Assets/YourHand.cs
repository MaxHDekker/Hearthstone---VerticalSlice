using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourHand : MonoBehaviour
{
    List<Card> cardsInHand = new List<Card>();
    public List<Card> choosableCards;

    public GameObject deck;
    private Deck cardDeck;

    void Start()
    {
        choosableCards = new List<Card>();

        cardDeck = deck.GetComponent<Deck>();
    }

    public void chooseCards()
    {
        for (int i = 0; i < choosableCards.Count; i++)
        {
            choosableCards[i] = cardDeck.GetTopDeck();
        }
    }

    public void TakeCard()
    {

    }
}
