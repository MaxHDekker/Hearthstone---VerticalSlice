using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
/*
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {

    public Transform parentToReturnTo = null;
    private Vector3 startScale;

    void Start()
    {
        print(this.transform.position);
        startScale = this.transform.localScale;

    }

	public void OnBeginDrag(PointerEventData eventData)
    {
        //		Debug.Log ("OnBeginDrag");
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
    {
//		Debug.Log ("OnDrag");

		this.transform.position = eventData.position;
	}
	
	public void OnEndDrag(PointerEventData eventData)
    {
        //		Debug.Log ("OnEndDrag");

        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(0.6f, 0.6f, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = startScale;
    }
}
*/