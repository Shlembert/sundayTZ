using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IDragHandler
{
    private RectTransform imageRectTransform;

    private void Start()
    {
        imageRectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragDelta = eventData.delta;

        Vector2 newPosition = imageRectTransform.anchoredPosition + dragDelta;

        imageRectTransform.anchoredPosition = newPosition;
    }
}
