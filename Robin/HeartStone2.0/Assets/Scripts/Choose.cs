using UnityEngine;
using UnityEngine.EventSystems;

public class Choose : MonoBehaviour
     , IPointerClickHandler
{
    public bool keep = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        keep = !keep;
    }
}
