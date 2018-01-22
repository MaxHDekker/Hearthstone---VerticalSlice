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

    private int manaCrystals;
    private int amountCards;

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

    public void ChosenCards()
    {
        for (int i = 0; i < amountCards; i++)
        {
            hand.ChosenCardBack(i);
        }
    }

    void InitiateNormalTurn()
    {
        manaCrystals += 1;

        hand.TakeCard();
    }
}
