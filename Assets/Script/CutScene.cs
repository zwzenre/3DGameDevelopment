using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public string sceneToLoad;

    public void nextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
