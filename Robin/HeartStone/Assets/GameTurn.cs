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
            yourTurn.firstTurn = true;
            aiTurn.firstTurn = false;
        }
        else
        {
            yourTurn.firstTurn = false;
            aiTurn.firstTurn = true;
        }
        StartCoroutine(chooseHand());
    }
    IEnumerator chooseHand()
    {


        yield return new WaitForSeconds(30);

        StartCoroutine(Turn());
    }
    IEnumerator Turn()
    {
        yourTurn.myTurn = true;

        yield return new WaitForSeconds(60);

        yourTurn.myTurn = false;

        SwitchTurns();

        StartCoroutine(Turn());
    }

    void SwitchTurns()
    {
        player1Turn = !player1Turn;
    }


}
