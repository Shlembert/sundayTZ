using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class ApplyColor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private Text colorText;

    private Image colorImage;
    private Vector2 _offsetScrool;

    private void Start()
    {
        colorImage = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _offsetScrool = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Vector2.Distance(Input.mousePosition, _offsetScrool) > 10f) return;

        Color targetColor = colorImage.color;
        ChangeColorAnimation(targetColor);
        colorText.text = targetColor.ToString();
        colorText.color = targetColor;
    }

    private void ChangeColorAnimation(Color targetColor)
    {
        objectRenderer.material.DOColor(targetColor, 1.5f);
    }
}
