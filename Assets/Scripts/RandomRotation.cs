using UnityEngine;
using DG.Tweening;

public class RandomRotation : MonoBehaviour
{
    private Vector3 randomAxis;

    private void Start()
    {
        randomAxis = Random.insideUnitSphere.normalized;

        RotateObject();
    }

    private void RotateObject()
    {
        float duration = Random.Range(5f, 7f);

        transform.DORotate(transform.eulerAngles + (randomAxis * 360f), duration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .OnComplete(RotateObject);
    }
}
