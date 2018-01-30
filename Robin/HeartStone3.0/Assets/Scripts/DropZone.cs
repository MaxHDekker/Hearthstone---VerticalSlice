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
            cardsOnTable.Add(scriptP1.cardsInHand[dScript.originSiblingIndex]);
            MakeMinions(scriptP1.cardsInHand[dScript.originSiblingIndex], cardsOnTableGO);
            scriptP1.manaCrystals -= cardInfo.card.manaCost;
            Destroy(d);
            dScript.GetIndex();
            scriptP1.cardsInHandGO.RemoveAt(dScript.originSiblingIndex);
            scriptP1.cardsInHand.RemoveAt(dScript.originSiblingIndex);
            scriptP1.UpdateHandPlacement();
            UpdateHandPlacement();
        }

    }

    void MakeMinions(Card card, List<GameObject> targetPlayer)
    {
        GameObject minion = Instantiate(prefabMinion, new Vector3(0, 0, 100), Quaternion.identity);
        RectTransform transformCard = minion.GetComponent<RectTransform>();
        cardDisplay = minion.GetComponent<CardDisplay>();
        cardDisplay.Setup(card);
        targetPlayer.Add(minion);
    }

    public void UpdateHandPlacement()
    {
        for (int i = 0; i < cardsOnTableGO.Count; i++)
        {
            cardsOnTableGO[i].transform.position = (HandPlacement(i, cardsOnTableGO.Count));
            //transformCard.eulerAngles = new Vector3(0, 0, CurveCards(i, cardsInHandGO.Count));
            if (cardsOnTableGO[i].GetComponent<Playable>() != null)
            {
                cardsOnTableGO[i].GetComponent<Playable>().GetTransform();
            }
        }
    }

    Vector2 HandPlacement(int i, float amountCards)
    {
        Vector2 pos;
        float offset = 90;
        float cardWidth = 90;
        float middleScreenWidth = 0 / 2;
        float middleScreenHeight = 0 / 2;

        pos.x = (middleScreenWidth - (offset + cardWidth) / 2) - (i * (offset + cardWidth)) + ((offset + cardWidth) / 2 * amountCards);
        pos.y = middleScreenHeight;

        return pos;
    }
}
