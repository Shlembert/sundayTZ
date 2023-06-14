using UnityEngine;

public class ImageViewController : MonoBehaviour
{
    public void ReturnToGallery()
    {
        SceneManagerController.Instance.SwitchScene(2);
    }
}
