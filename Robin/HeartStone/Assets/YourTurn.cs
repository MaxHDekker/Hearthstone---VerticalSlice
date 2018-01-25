using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourTurn : MonoBehaviour
{
    [SerializeField]
    private GameObject yourHand;
    public YourHand hand;

    public bool firstTurn;
    public bool myTurn = false;

    public int manaCrystals;
    public int amountCards;
    private int disposedCards;

    void Start()
    {
        hand = yourHand.GetComponent<YourHand>();
    }

    public void InitiateChooseCards()
    {
        if(firstTurn)
        {
            amountCards = 3;
        }
        else
        {
            amountCards = 4;
        }
        for (int i = 0; i < amountCards; i++)
        {
            hand.ChooseCards(amountCards, i);
        }
    }

    public void CleanChosenCards()
    {
        for (int i = 0; i < amountCards; i++)
        {
            disposedCards = hand.ChosenCardBack(amountCards, i);
        }
        for (int i = 0; i < disposedCards; i++)
        {
            hand.TakeCard();
        }

        hand.UpdateHandPlacement();

        hand.cardDeck.Shuffle();

        hand.choosableCards.Clear();
        hand.choosableCardsGO.Clear();
    }

    public void InitiateNormalTurn()
    {
        manaCrystals += 1;

        hand.TakeCard();
    }
}
