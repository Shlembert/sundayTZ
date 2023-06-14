using UnityEngine;

public class OrientationController : MonoBehaviour
{
    public enum SceneOrientation
    {
        Portrait,
        Landscape
    }

    [SerializeField] private SceneOrientation sceneOrientation;

    private void Start()
    {
        ApplyOrientation();
    }

    private void ApplyOrientation()
    {
        if (sceneOrientation == SceneOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
        }
        else if (sceneOrientation == SceneOrientation.Landscape)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
        }
    }
}
