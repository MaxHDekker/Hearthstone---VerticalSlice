using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    [SerializeField]
    public List<Card> cards = new List<Card>();
    [SerializeField]
    private CardDatabase cardLibrary;

    void Start()
    {
        for (var i = 0; i < 30; i++)
        {
            Add(cardLibrary.GetRandomCardFromDatabase());
        }
    }
    public void Add(Card card)
    {
        cards.Add(card);
    }

    public Card GetTopDeck()
    {
        var topCard = cards[0];
        cards.RemoveAt(0);
        return topCard;
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

}
