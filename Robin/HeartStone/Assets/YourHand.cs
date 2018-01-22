using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourHand : MonoBehaviour
{
    public List<Card> cardsInHand = new List<Card>();
    public List<Card> choosableCards = new List<Card>();

    public GameObject deck;
    public GameObject cardPrefab;
    public GameObject canvas;
    private RectTransform canvasTransform;
    private CardDisplay cardDisplay;
    private Deck cardDeck;

    float[] pos;

    void Start()
    {
        cardDeck = deck.GetComponent<Deck>();
        canvasTransform = canvas.GetComponent<RectTransform>();
    }

    public GameObject ChooseCards(int amountCards)
    {
        for (int i = 0; i < amountCards; i++)
        {
            choosableCards.Add(cardDeck.GetTopDeck());
            GameObject cards = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            cards.transform.SetParent(this.transform, false);
            cardDisplay = cards.GetComponent<CardDisplay>();
            cardDisplay.card = choosableCards[i];
            RectTransform transformCard = cards.GetComponent<RectTransform>();
            transformCard.position = new Vector3(i*100, canvasTransform.rect.height/2, 0);
            cards.AddComponent<Choose>();
        }
        return cards;
    }

    public void ChosenCardBack(int amountCards)
    {
        for (int i = 0; i <= amountCards; i++)
        {
            print(cards[i]);
            if (cards[i].GetComponent<Choose>().keep) 
            {
//                cardsInHand.Add(choosableCards[i]);
            }
            else
            {
//                cardDeck.cards.Add(choosableCards[i]);
            }
        }
    }
    private float ChoosePlacement(float amountCards, int i)
    {
        int middleCard;
        float middleScreen = (canvasTransform.rect.width / 2);
        middleCard = Mathf.CeilToInt(amountCards / 2);

        pos[middleCard] = middleScreen;
        return pos[i];
    }

    public void TakeCard()
    {
        cardsInHand.Add(cardDeck.GetTopDeck());
    }
}
