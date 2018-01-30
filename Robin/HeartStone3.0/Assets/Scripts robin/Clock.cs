using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private Player1 scriptP1;
    private Player2 scriptP2;

    void Start()
    {
        scriptP1 = player1.GetComponent<Player1>();
        scriptP2 = player2.GetComponent<Player2>();
        if(Random.value > 0.5f)
        {
            scriptP1.choosableCardsAmount = 3;
            scriptP1.myTurn = true;
        }
        else
        {
            scriptP1.choosableCardsAmount = 4;
            scriptP1.myTurn = false;
        }
        print(scriptP1.myTurn);
        StartCoroutine(ChooseHand());
    }
    IEnumerator ChooseHand()
    {
        scriptP1.InitiateChooseCards();
        print("choosing hand");

        yield return new WaitForSeconds(4);

        scriptP1.CleanChosenCards();

        StartCoroutine(Turn());
    }
    IEnumerator Turn()
    {
        scriptP1.InitiateNormalTurn();

        yield return new WaitForSeconds(10);

        SwitchTurns();

        StartCoroutine(Turn());
    }

    void SwitchTurns()
    {
        print("switching");
        scriptP1.myTurn = !scriptP1.myTurn;
    }


}
