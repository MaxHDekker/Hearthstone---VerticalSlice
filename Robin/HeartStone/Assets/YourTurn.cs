using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourTurn : MonoBehaviour
{
    [SerializeField]
    private GameObject yourHand;
    private YourHand hand;

    public bool firstTurn;
    public bool myTurn = false;

    private int manaCrystals;

    void Start()
    {
        hand = yourHand.GetComponent<YourHand>();
    }

    public void initiateChooseCards()
    {
        hand.chooseCards();
    }

    void InitiateNormalTurn()
    {
        manaCrystals += 1;

        hand.TakeCard();
    }
}
