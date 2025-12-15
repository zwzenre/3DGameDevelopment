using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public string sceneToLoad;

    private void Start()
    {
        AudioManager.instance.PlayGameBGM();

    }


    public void nextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
