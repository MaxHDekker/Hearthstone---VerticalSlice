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
        if(scriptP1.myTurn)
        {
            GameObject d = eventData.pointerDrag;
            Playable dScript = d.GetComponent<Playable>();
            CardDisplay cardInfo = d.GetComponent<CardDisplay>();

            if (cardInfo.card.manaCost <= scriptP1.manaCrystals)
            {
                cardsOnTable.Add(scriptP1.cardsInHand[dScript.originSiblingIndex]);
                GameObject minion = MakeMinions(scriptP1.cardsInHand[dScript.originSiblingIndex], cardsOnTableGO);
                minion.tag = "p1";
                scriptP1.manaCrystals -= cardInfo.card.manaCost;
                Destroy(d);
                dScript.GetIndex();
                scriptP1.cardsInHandGO.RemoveAt(dScript.originSiblingIndex);
                scriptP1.cardsInHand.RemoveAt(dScript.originSiblingIndex);
                scriptP1.UpdateHandPlacement();
                UpdateHandPlacement();
            }
        }
    }

    GameObject MakeMinions(Card card, List<GameObject> targetPlayer)
    {
        GameObject minion = Instantiate(prefabMinion, new Vector3(0, 0, 95), Quaternion.identity);
        RectTransform transformCard = minion.GetComponent<RectTransform>();
        cardDisplay = minion.GetComponent<CardDisplay>();
        cardDisplay.Setup(card);
        targetPlayer.Add(minion);

        return minion;
    }

    public void UpdateHandPlacement()
    {
        for (int i = 0; i < cardsOnTableGO.Count; i++)
        {
            cardsOnTableGO[i].transform.position = (Placement(i, cardsOnTableGO));
        }
    }

    Vector3 Placement(int i, List<GameObject> cards)
    {
        Vector3 pos;
        float offset = 10f;
        MeshRenderer mesh = cards[i].GetComponent<MeshRenderer>();
        float cardWidth = mesh.bounds.size.x;
        float middleScreenWidth = 0;
        float middleScreenHeight = 0;

        pos.x = (middleScreenWidth - (offset + cardWidth) / 2) - (i * (offset + cardWidth)) + ((offset + cardWidth) / 2 * cards.Count);
        pos.y = middleScreenHeight - 10;
        pos.z = 95;

        return pos;
    }
}
