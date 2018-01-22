using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourHand : MonoBehaviour
{
    public List<Card> cardsInHand = new List<Card>();
    public List<Card> choosableCards = new List<Card>();
    public List<GameObject> cardsChosen = new List<GameObject>();

    public GameObject deck;
    public GameObject cardPrefab;
    public GameObject canvas;
    private RectTransform canvasTransform;
    private CardDisplay cardDisplay;
    private Deck cardDeck;

 

    void Start()
    {
        cardDeck = deck.GetComponent<Deck>();
        canvasTransform = canvas.GetComponent<RectTransform>();
    }

    public void ChooseCards(int amountCards, int i)
    {
        choosableCards.Add(cardDeck.GetTopDeck());
        GameObject cards = MakeCard(choosableCards[i]);
        RectTransform transformCard = cards.GetComponent<RectTransform>();
        transformCard.position = new Vector3(ChoosePlacement(amountCards, i), canvasTransform.rect.height / 2, 0);
        cards.AddComponent<Choose>();
        cardsChosen.Add(cards);
    }

    GameObject MakeCard(Card card)
    {
        GameObject cards = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cards.transform.SetParent(this.transform, false);
        cardDisplay = cards.GetComponent<CardDisplay>();
        cardDisplay.Setup(card);
        return cards;
    }

    public void ChosenCardBack(int i)
    {
        if (cardsChosen[i].GetComponent<Choose>().keep) 
        {
                cardsInHand.Add(choosableCards[i]);
        }
        else
        {
                cardDeck.cards.Add(choosableCards[i]);
        }
    }
    private float ChoosePlacement(float amountCards, int i)
    {
        float pos;
        float offset = 100;
        float middleScreen = (canvasTransform.rect.width / 2);
        float deelbaar = (amountCards % 2);

        if(deelbaar == 1)
        {
            pos = (middleScreen) + (0) - (i*offset);
        }
        else
        {
            pos = (middleScreen - offset / 2) + (0) - (i*offset);
        }

        return pos;
    }

    public void TakeCard()
    {
        cardsInHand.Add(cardDeck.GetTopDeck());
    }
}
