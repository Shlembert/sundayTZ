using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeColorRamdom : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private Text colorText;

    private Color previousColor;

    private void Start()
    {
        previousColor = objectRenderer.material.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Color targetColor = Random.ColorHSV();

        ChangeColorAnimation(targetColor);
    }

    private void ChangeColorAnimation(Color targetColor)
    {
        objectRenderer.material.DOColor(targetColor, 1.5f);
        colorText.text = targetColor.ToString();
        colorText.color = targetColor;
    }
}
