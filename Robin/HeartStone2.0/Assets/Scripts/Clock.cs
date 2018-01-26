using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private Player1 ScriptP1;
    private Player2 ScriptP2;

    void Start()
    {
        ScriptP1 = player1.GetComponent<Player1>();
        ScriptP2 = player2.GetComponent<Player2>();
        if (Random.value > 0.5f)
        {
            ScriptP1.choosableCardsAmount = 3;
        }
        else
        {
            ScriptP1.choosableCardsAmount = 4;
        }
        StartCoroutine(ChooseHand());
    }

    IEnumerator ChooseHand()
    {
        ScriptP1.InitiateChooseCards();
//        ScriptP2.InitiateChooseCards();
        print("choosing hand");

        yield return new WaitForSeconds(10);

        ScriptP1.InitiateChooseCleanUp();

//        StartCoroutine(Turn());
    }
}
