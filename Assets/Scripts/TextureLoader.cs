using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextureLoader : MonoBehaviour
{
    [SerializeField] private  RawImage rawImage;
    [SerializeField] private GameObject downloadScreen;
    [SerializeField] private Image fill;

    private void Start()
    {
        StartCoroutine(AnimateDownloadScreen());

        // ��������� ����������� �������� �� PlayerPrefs
        string textureData = PlayerPrefs.GetString("SavedTexture");
        byte[] textureBytes = System.Convert.FromBase64String(textureData);
        Texture2D savedTexture = new Texture2D(1, 1);
        savedTexture.LoadImage(textureBytes);

        // ������������� �������� � RawImage
        rawImage.texture = savedTexture;
    }

    private IEnumerator AnimateDownloadScreen()
    {
        float duration = 0f;
        float elapsedTime = 0f;
        float startFillAmount = fill.fillAmount;
        float targetFillAmount = 1f;

        while (elapsedTime < duration)
        {
            float fillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, elapsedTime / duration);
            fill.fillAmount = fillAmount;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fill.gameObject.SetActive(false);

        // Fade out animation
        CanvasGroup canvasGroup = downloadScreen.GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0f, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            // Deactivate the download screen
            downloadScreen.SetActive(false);
        });
    }
}
