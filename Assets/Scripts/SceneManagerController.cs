using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    private static SceneManagerController _instance;

    public static SceneManagerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SceneManagerController>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<SceneManagerController>();
                    singletonObject.name = "SceneManagerSingleton";
                    DontDestroyOnLoad(singletonObject);
                }
            }

            return _instance;
        }
    }

    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

