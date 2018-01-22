using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourHand : MonoBehaviour
{
    public List<Card> cardsInHand = new List<Card>();
    public List<GameObject> cardsInHandGO = new List<GameObject>();

    public List<Card> choosableCards = new List<Card>();
    public List<GameObject> choosableCardsGO = new List<GameObject>();

    public GameObject deck;
    public GameObject cardPrefab;
    public GameObject canvas;
    public Deck cardDeck;
    private RectTransform canvasTransform;
    private CardDisplay cardDisplay;

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
        transformCard.position = (ChoosePlacement(amountCards, transformCard.rect.width , i));
        cards.AddComponent<Choose>();
        choosableCardsGO.Add(cards);
    }

    GameObject MakeCard(Card card)
    {
        GameObject cards = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cards.transform.SetParent(this.transform, false);
        cardDisplay = cards.GetComponent<CardDisplay>();
        cardDisplay.Setup(card);
        return cards;
    }

    public void ChosenCardBack(int amountcards, int i)
    {
        if (choosableCardsGO[i].GetComponent<Choose>().keep) 
        {
            cardsInHand.Add(choosableCards[i]);
            cardsInHandGO.Add(choosableCardsGO[i]);
        }
        else
        {
            cardDeck.cards.Add(choosableCards[i]);
            Destroy(choosableCardsGO[i]);
        }
    }
    public void CardToHand(int i, int amountCards)
    {
        RectTransform transformCard = cardsInHandGO[i].GetComponent<RectTransform>();
        transformCard.position = (HandPlacement(i, amountCards));
    }

    Vector2 ChoosePlacement(float amountCards,float cardWidth, int i)
    {
        Vector2 pos;
        float offset = 30;
        float middleScreenWidth = (canvasTransform.rect.width / 2);
        float middleScreenHeight = canvasTransform.rect.height / 2;

        pos.x = (middleScreenWidth - (offset + cardWidth) / 2) - (i * (offset + cardWidth)) + ((offset + cardWidth) / 2 * amountCards);
        pos.y = middleScreenHeight;

        return pos;
    }

    Vector2 HandPlacement(float amountCards, int i)
    {
        Vector2 pos;
        float offset = 20;
        float middleScreen = (canvasTransform.rect.width / 2);

        pos.x = (middleScreen - (offset) / 2) - (i * (offset)) + ((offset) / 2 * amountCards);
        pos.y = canvasTransform.rect.width / 8;

        return pos;
    }

    public void TakeCard()
    {
        cardsInHand.Add(cardDeck.GetTopDeck());
        GameObject card = MakeCard(cardsInHand[cardsInHand.Count - 1]);
        cardsInHandGO.Add(card);
    }
}
