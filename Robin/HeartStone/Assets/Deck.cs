using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    [SerializeField]
    private GameObject[] cards = new GameObject[30];
    private int count = 0;

    public void Add(GameObject card)
    {
        cards[count] = card;
        count++;
    }
    public GameObject GetTopDeck()
    {
        count--;
        return cards[count];
    }
    void Shuffle()
    {
        for (int t = 0; t < cards.Length; t++)
        {
            GameObject tmp = cards[t];
            int r = Random.Range(t, cards.Length);
            cards[t] = cards[r];
            cards[r] = tmp;
        }
    }

}
