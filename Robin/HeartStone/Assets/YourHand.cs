using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourHand : MonoBehaviour
{
    public List<Card> cardsInHand = new List<Card>();
    public List<GameObject> cardsInHandGO = new List<GameObject>();

    public List<Card> choosableCards = new List<Card>();
    public List<GameObject> choosableCardsGO = new List<GameObject>();

    public AnimationCurve curveGraph;

    public GameObject deck;
    public GameObject cardPrefab;
    public GameObject canvas;
    public Deck cardDeck;
    private RectTransform canvasTransform;
    private CardDisplay cardDisplay;

    int disposedCards;
    private float originSizeCards;

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
        transformCard.localScale = transformCard.localScale * 0.9f;
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

    public int ChosenCardBack(int amountCards, int i)
    {
        if (choosableCardsGO[i].GetComponent<Choose>().keep) 
        {
            Destroy(choosableCardsGO[i]);
            cardsInHand.Add(choosableCards[i]);
            GameObject card = MakeCard(choosableCards[i]);
            card.transform.localScale = card.transform.localScale * 0.6f;
            card.AddComponent<Playable>();
            cardsInHandGO.Add(card);
        }
        else
        {
            cardDeck.cards.Add(choosableCards[i]);
            Destroy(choosableCardsGO[i]);
            disposedCards++;
        }
        return disposedCards;
    }


    Vector2 ChoosePlacement(float amountCards,float cardWidth, int i)
    {
        Vector2 pos;
        float offset = 200;
        float middleScreenWidth = (canvasTransform.rect.width / 2);
        float middleScreenHeight = canvasTransform.rect.height / 2;

        pos.x = (middleScreenWidth - (offset + cardWidth) / 2) - (i * (offset + cardWidth)) + ((offset + cardWidth) / 2 * amountCards);
        pos.y = middleScreenHeight;

        return pos;
    }

    Vector2 HandPlacement(int i, float amountCards)
    {
        Vector2 pos;
        float offset = 90;
        float middleScreenWidth = canvasTransform.rect.width / 2;
        float bottomScreenHeight = canvasTransform.rect.height;

        pos.x = (middleScreenWidth) + i*offset - offset/2*amountCards;
        pos.y = bottomScreenHeight - bottomScreenHeight + 50;

        return pos;
    }
    float CurveCards(int i, int amountCards)
    {
        float curve;

        curve = curveGraph.Evaluate(i);

        return curve;
    }
    float SizeCards()
    {
        return 0;
    }

    public void TakeCard()
    {
        cardsInHand.Add(cardDeck.GetTopDeck());
        GameObject card = MakeCard(cardsInHand[cardsInHand.Count - 1]);
        cardsInHandGO.Add(card);
        card.AddComponent<Playable>();
        card.transform.localScale = card.transform.localScale * 0.6f;
        UpdateHandPlacement();
    }

    public void UpdateHandPlacement()
    {
        for (int i = 0; i < cardsInHandGO.Count; i++)
        {
            RectTransform transformCard = cardsInHandGO[i].GetComponent<RectTransform>();
            transformCard.position = (HandPlacement(i, cardsInHandGO.Count));
            //transformCard.eulerAngles = new Vector3(0, 0, CurveCards(i, cardsInHandGO.Count));
            if (cardsInHandGO[i].GetComponent<Playable>() != null)
            {
                cardsInHandGO[i].GetComponent<Playable>().GetTransform();
            }
        }
    }
}

