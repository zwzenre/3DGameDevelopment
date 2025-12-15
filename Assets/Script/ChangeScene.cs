using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void NextScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SettingScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Debug.Log("Quit pressed!");
        Application.Quit();
    }


}
