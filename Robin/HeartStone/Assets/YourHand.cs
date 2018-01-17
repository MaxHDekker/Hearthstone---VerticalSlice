using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourHand : MonoBehaviour
{
    List<Card> cardsInHand = new List<Card>();
    public List<Card> choosableCards = new List<Card>();

    public GameObject deck;
    private Deck cardDeck;

    void Start()
    {
        cardDeck = deck.GetComponent<Deck>();
    }

    public void chooseCards()
    {
        for (int i = 0; i < 3; i++)
        {
            choosableCards.Add(cardDeck.GetTopDeck());
        }
    }

    public void ShowCard()
    {

    }

    public void TakeCard()
    {

    }
}
