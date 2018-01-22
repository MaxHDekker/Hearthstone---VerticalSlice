using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTurn : MonoBehaviour {

    bool player1Turn = true;

    public GameObject player1;
    public GameObject player2;

    private YourTurn yourTurn;
    private AiTurn aiTurn;

    void Start()
    {
        yourTurn = player1.GetComponent<YourTurn>();
        aiTurn = player2.GetComponent<AiTurn>();

        if(Random.value > 0.5f)
        {
            player1Turn = true;
            yourTurn.firstTurn = true;
            aiTurn.firstTurn = false;
        }
        else
        {
            player1Turn = false;
            yourTurn.firstTurn = false;
            aiTurn.firstTurn = true;
        }
        print(yourTurn.firstTurn);
        StartCoroutine(ChooseHand());
    }
    IEnumerator ChooseHand()
    {
        yourTurn.InitiateChooseCards();
        print("choosing hand");

        yield return new WaitForSeconds(10);

        yourTurn.ChosenCards();
        yourTurn.hand.cardDeck.Shuffle();
        yourTurn.hand.choosableCards.Clear();
        yourTurn.hand.choosableCardsGO.Clear();
        StartCoroutine(Turn());
    }
    IEnumerator Turn()
    {
        if(player1Turn)
        {
            yourTurn.InitiateNormalTurn();
        }
        else
        {
            print("enemyTurn");
        }
        print("normalTurn");

        yield return new WaitForSeconds(60);

        SwitchTurns();

        StartCoroutine(Turn());
    }

    void SwitchTurns()
    {
        print("switching");
        player1Turn = !player1Turn;
    }


}
