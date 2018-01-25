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

    private YourTurn playerScript;
    private YourHand handScript;

    void Start()
    {
        playerScript = player.GetComponent<YourTurn>();
        handScript = hand.GetComponent<YourHand>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject d = eventData.pointerDrag;
        Playable dScript = d.GetComponent<Playable>();
        if(d.GetComponent<CardDisplay>().card.manaCost <= playerScript.manaCrystals)
        {
            MakeMinions();
            Destroy(d);
            dScript.GetIndex();
            handScript.cardsInHandGO.RemoveAt(dScript.originSiblingIndex);
            handScript.cardsInHand.RemoveAt(dScript.originSiblingIndex);
            handScript.UpdateHandPlacement();
        }
    }

    void MakeMinions()
    {

    }
}
