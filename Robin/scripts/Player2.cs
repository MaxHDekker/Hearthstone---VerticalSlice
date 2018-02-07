using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [Header("Variables")]
    public int manaCrystalsTotal;
    public int manaCrystals;
    public int choosableCardsAmount;
    public int health = 30;
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

}
