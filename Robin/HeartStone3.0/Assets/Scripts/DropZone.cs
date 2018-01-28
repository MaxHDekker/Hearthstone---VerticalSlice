using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour
    , IDropHandler
{
    public GameObject player;
    public GameObject hand;

    public List<Card> cardsOnTable = new List<Card>();
    public List<GameObject> cardsOnTableGO = new List<GameObject>();

    private Player1 scriptP1;


    void Start()
    {
        scriptP1 = player.GetComponent<Player1>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject d = eventData.pointerDrag;
        Playable dScript = d.GetComponent<Playable>();
        if(d.GetComponent<CardDisplay>().card.manaCost <= scriptP1.manaCrystals)
        {
            MakeMinions();
            Destroy(d);
            dScript.GetIndex();
            scriptP1.cardsInHandGO.RemoveAt(dScript.originSiblingIndex);
            scriptP1.cardsInHand.RemoveAt(dScript.originSiblingIndex);
            scriptP1.UpdateHandPlacement();
        }
    }

    void MakeMinions()
    {

    }
}
