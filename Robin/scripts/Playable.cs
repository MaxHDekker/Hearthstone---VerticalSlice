using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Playable : MonoBehaviour
    , IBeginDragHandler
    , IDragHandler
    , IEndDragHandler
    , IPointerEnterHandler
    , IPointerExitHandler

{

    public int originSiblingIndex;
    public int listIndex;

    public bool pointEnter;
    [SerializeField]
    private GameObject Player1;

    private Player1 p1Script;
    private RectTransform rectTransform;
    private Vector2 Location;
    private Vector2 size;

    private bool drag = false;

    void Start()
    {
        p1Script = GameObject.Find("Player1").GetComponent<Player1>();
        StartCoroutine(CheckIndex());
    }

    IEnumerator CheckIndex()
    {
        yield return new WaitForSeconds(1);

        GetIndex();
    }

    public void GetIndex()
    {
        originSiblingIndex = this.transform.GetSiblingIndex();
    }

    public void GetTransform()
    {
        Location = this.transform.position;
        size = this.transform.localScale;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (p1Script)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(p1Script.myTurn)
        {
            this.transform.position = eventData.position;
            this.transform.localScale = size;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (p1Script)
        {
            this.transform.position = Location;

            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 220);
        this.transform.localScale = this.transform.localScale * 2f;
        this.transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.position = Location;
        this.transform.localScale = size;
        this.transform.SetSiblingIndex(originSiblingIndex);
    }

}
