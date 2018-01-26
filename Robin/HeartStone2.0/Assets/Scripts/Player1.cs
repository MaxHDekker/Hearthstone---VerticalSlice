using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour 
{
    public int choosableCardsAmount;

    public List<Card> deckP1 = new List<Card>();

    public List<Card> cardsInHand = new List<Card>();
    public List<GameObject> cardsInHandGO = new List<GameObject>();

    [SerializeField]
    private List<Card> choosableCards = new List<Card>();

    [SerializeField]
    private List<GameObject> choosableCardsGO = new List<GameObject>();

    [SerializeField]
    private GameObject deckManager;

    [SerializeField]
    private GameObject canvas;

    private RectTransform canvasTransform;
    private DeckManager deckScript;

    private int disposedCards;

    void Start ()
    {
        deckScript = deckManager.GetComponent<DeckManager>();
        canvasTransform = canvas.GetComponent<RectTransform>();
    }

    public void InitiateChooseCards()
    {
        for (int i = 0; i < choosableCardsAmount; i++)
        {
            print(deckScript);
            choosableCards.Add(deckScript.GetTopDeck(deckP1));
            GameObject card = deckScript.MakeCard(choosableCards[i]);
            RectTransform transformCard = card.GetComponent<RectTransform>();
            card.transform.SetParent(this.transform, false);
            transformCard.localScale = transformCard.localScale * 0.9f;
            transformCard.position = (ChoosingCardPosition(choosableCardsAmount, transformCard.rect.width, i));
            card.AddComponent<Choose>();
            choosableCardsGO.Add(card);
        }
    }
    public void InitiateChooseCleanUp()
    {
        for (int i = 0; i < choosableCardsAmount; i++)
        {
            disposedCards = ChosenCardBack(i);
        }
        for (int i = 0; i < disposedCards; i++)
        {
            deckScript.TakeCard(deckP1, cardsInHand, cardsInHandGO);
        }
        UpdateHandPlacement();

        deckScript.Shuffle(deckP1);

        choosableCards.Clear();
        choosableCardsGO.Clear();
    }

    public int ChosenCardBack(int i)
    {
        if (choosableCardsGO[i].GetComponent<Choose>().keep)
        {
            cardsInHand.Add(choosableCards[i]);
            GameObject card = deckScript.MakeCard(choosableCards[i]);
            card.transform.localScale = card.transform.localScale * 0.6f;
            card.AddComponent<Playable>();
            cardsInHandGO.Add(card);
            Destroy(choosableCardsGO[i]);
        }
        else
        {
            deckP1.Add(choosableCards[i]);
            Destroy(choosableCardsGO[i]);
            disposedCards++;
        }
        return disposedCards;
    }
    Vector2 ChoosingCardPosition(int choosableCardsAmount, float cardWidth, int i)
    {
        Vector2 pos;
        float offset = 200;
        float middleScreenWidth = (canvasTransform.rect.width / 2);
        float middleScreenHeight = canvasTransform.rect.height / 2;

        pos.x = (middleScreenWidth - (offset + cardWidth) / 2) - (i * (offset + cardWidth)) + ((offset + cardWidth) / 2 * choosableCardsAmount);
        pos.y = middleScreenHeight;

        return pos;
    }

    Vector2 HandPlacement(int i, float amountCards)
    {
        Vector2 pos;
        float offset = 120;
        float middleScreenWidth = canvasTransform.rect.width / 2;
        float bottomScreenHeight = canvasTransform.rect.height;

        pos.x = (middleScreenWidth) + i * offset - offset / 2 * amountCards;
        pos.y = bottomScreenHeight - bottomScreenHeight + 50;

        return pos;
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
