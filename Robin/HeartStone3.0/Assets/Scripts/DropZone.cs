using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour
    , IDropHandler
{
    public GameObject player;
    public GameObject prefabMinion;

    public List<Card> cardsOnTable = new List<Card>();
    public List<GameObject> cardsOnTableGO = new List<GameObject>();

    private Player1 scriptP1;
    private CardDisplay cardDisplay;


    void Start()
    {
        scriptP1 = player.GetComponent<Player1>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject d = eventData.pointerDrag;
        Playable dScript = d.GetComponent<Playable>();
        CardDisplay cardInfo = d.GetComponent<CardDisplay>();
        if (cardInfo.card.manaCost <= scriptP1.manaCrystals)
        {
            MakeMinions(scriptP1.cardsInHand[dScript.originSiblingIndex]);
            scriptP1.manaCrystals -= cardInfo.card.manaCost;
            Destroy(d);
            dScript.GetIndex();
            scriptP1.cardsInHandGO.RemoveAt(dScript.originSiblingIndex);
            scriptP1.cardsInHand.RemoveAt(dScript.originSiblingIndex);
            scriptP1.UpdateHandPlacement();

        }
    }

    void MakeMinions(Card card)
    {
        GameObject minion = Instantiate(prefabMinion, new Vector3(0, 0, 100), Quaternion.identity);
        cardDisplay = minion.GetComponent<CardDisplay>();
        cardDisplay.Setup(card);
    }

}
