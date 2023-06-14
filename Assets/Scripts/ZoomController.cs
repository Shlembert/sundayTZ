using UnityEngine;
using UnityEngine.UI;

public class ZoomController : MonoBehaviour
{
    private float initialDistance;
    private Vector2 initialSize;
    private Vector3 origPosition;
    private bool doubleTap = false;
    private float doubleTapTime = 0.3f;
    private float lastTapTime = 0f;

    [SerializeField] private RawImage rawImage;

    private void Start()
    {
        initialSize = rawImage.rectTransform.sizeDelta;
        origPosition = rawImage.rectTransform.position;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Zoom();
        }
        else
        {
            ResetZoom();
        }

        CheckDoubleTap();
    }

    private void Zoom()
    {
        Touch touch1 = Input.GetTouch(0);
        Touch touch2 = Input.GetTouch(1);

        if (touch2.phase == TouchPhase.Began)
        {
            initialDistance = Vector2.Distance(touch1.position, touch2.position);
        }
        else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
        {
            float currentDistance = Vector2.Distance(touch1.position, touch2.position);
            float scaleFactor = currentDistance / initialDistance;

            Vector2 newSize = initialSize * scaleFactor;
            rawImage.rectTransform.sizeDelta = newSize;
        }
    }

    private void ResetZoom()
    {
        if (doubleTap)
        {
            doubleTap = false;
            rawImage.rectTransform.sizeDelta = initialSize;
            rawImage.rectTransform.position = origPosition;
        }

        initialDistance = 0;
    }

    private void CheckDoubleTap()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - lastTapTime < doubleTapTime)
                {
                    doubleTap = true;
                }
                lastTapTime = Time.time;
            }
        }
    }
}
