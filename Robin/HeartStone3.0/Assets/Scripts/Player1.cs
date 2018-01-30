using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [Header("Variables")]
    public int manaCrystalsTotal;
    public int manaCrystals;
    public int choosableCardsAmount;
    public bool myTurn = false;
    [Space(20)]

    [Header("Deck&Hand")]
    public List<Card> deck = new List<Card>();

    public List<Card> cardsInHand = new List<Card>();
    public List<GameObject> cardsInHandGO = new List<GameObject>();
    [Space(20)]

    [Header("choosableCards")]
    public List<Card> choosableCards = new List<Card>();
    public List<GameObject> choosableCardsGO = new List<GameObject>();
    [Space(20)]

    [Header("GameObjects")]
    [SerializeField]
    private GameObject deckM;
    [SerializeField]
    private GameObject canvas;
    [Space(20)]

    private RectTransform canvasTransform;
    private CardDisplay cardDisplay;
    private DeckManager deckManager;

    private AnimationCurve curveGraph;

    private int disposedCards;
    private float originSizeCards;

    void Start()
    {
        deckManager = deckM.GetComponent<DeckManager>();
        canvasTransform = canvas.GetComponent<RectTransform>();
    }

    public void InitiateChooseCards()
    {
        for (int i = 0; i < choosableCardsAmount; i++)
        {
            ChooseCards(choosableCardsAmount, i);
        }
    }

    public void CleanChosenCards()
    {
        for (int i = 0; i < choosableCardsAmount; i++)
        {
            disposedCards = ChosenCardBack(choosableCardsAmount, i);
        }
        for (int i = 0; i < disposedCards; i++)
        {
            deckManager.TakeCard(deck, cardsInHand, cardsInHandGO, this.transform);
        }

        UpdateHandPlacement();

        deckManager.Shuffle(deck);

        choosableCards.Clear();
        choosableCardsGO.Clear();
    }

    public void InitiateNormalTurn()
    {
        manaCrystalsTotal += 1;
        manaCrystals = manaCrystalsTotal;

        deckManager.TakeCard(deck, cardsInHand, cardsInHandGO, this.transform);
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
    Vector2 HandPlacement(int i, float amountCards)
    {
        Vector2 pos;
        float offset = 90;
        float middleScreenWidth = canvasTransform.rect.width / 2;
        float bottomScreenHeight = canvasTransform.rect.height;

        pos.x = (middleScreenWidth) + i * offset - offset / 2 * amountCards;
        pos.y = bottomScreenHeight - bottomScreenHeight + 50;

        return pos;
    }

    void ChooseCards(int amountCards, int i)
    {
        choosableCards.Add(deckManager.GetTopDeck(deck));
        GameObject cards = deckManager.MakeCard(choosableCards[i], this.transform);
        RectTransform transformCard = cards.GetComponent<RectTransform>();
        transformCard.localScale = transformCard.localScale * 0.9f;
        transformCard.position = (ChoosePlacement(amountCards, transformCard.rect.width, i));
        cards.AddComponent<Choose>();
        choosableCardsGO.Add(cards);
    }

    int ChosenCardBack(int amountCards, int i)
    {
        if (choosableCardsGO[i].GetComponent<Choose>().keep)
        {
            Destroy(choosableCardsGO[i]);
            cardsInHand.Add(choosableCards[i]);
            GameObject card = deckManager.MakeCard(choosableCards[i], this.transform);
            card.transform.localScale = card.transform.localScale * 0.6f;
            card.AddComponent<Playable>();
            cardsInHandGO.Add(card);
        }
        else
        {
            deck.Add(choosableCards[i]);
            Destroy(choosableCardsGO[i]);
            disposedCards++;
        }
        return disposedCards;
    }


    Vector2 ChoosePlacement(float amountCards, float cardWidth, int i)
    {
        Vector2 pos;
        float offset = 200;
        float middleScreenWidth = (canvasTransform.rect.width / 2);
        float middleScreenHeight = canvasTransform.rect.height / 2;

        pos.x = (middleScreenWidth - (offset + cardWidth) / 2) - (i * (offset + cardWidth)) + ((offset + cardWidth) / 2 * amountCards);
        pos.y = middleScreenHeight;

        return pos;
    }

    float CurveCards(int i, int amountCards)
    {
        float curve;

        curve = curveGraph.Evaluate(i);

        return curve;
    }
}
