using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;

    private Player1 player1;
    private Player2 player2;

    [SerializeField]
    private CardDatabase cardLibrary;
    [SerializeField]
    private GameObject cardPrefab;

    private CardDisplay cardDisplay;

    private int disposedCards;

    void Start()
    {
        player1 = P1.GetComponent<Player1>();
        player2 = P2.GetComponent<Player2>();
        for (var i = 0; i < 30; i++)
        {
            Add(cardLibrary.GetRandomCardFromDatabase(), player1.deckP1);
//            Add(cardLibrary.GetRandomCardFromDatabase(), player2.deckP2);
        }
    }

    public void Add(Card card, List<Card> deck)
    {
        deck.Add(card);
    }

    public Card GetTopDeck(List<Card> deck)
    {
        var topCard = deck[0];
        deck.RemoveAt(0);
        return topCard;
    }

    public GameObject MakeCard(Card card)
    {
        GameObject cards = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

        cardDisplay = cards.GetComponent<CardDisplay>();
        cardDisplay.Setup(card);

        return cards;
    }

    public void TakeCard(List<Card> deck, List<Card> hand, List<GameObject> handGO)
    {
        hand.Add(GetTopDeck(deck));
        GameObject card = MakeCard(hand[hand.Count - 1]);
        handGO.Add(card);
        card.AddComponent<Playable>();
        card.transform.localScale = card.transform.localScale * 0.6f;
//        UpdateHandPlacement();
    }

    public void Shuffle(List<Card> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = UnityEngine.Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }
}
