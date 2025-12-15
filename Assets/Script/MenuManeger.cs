using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string sceneToLoad;
    private void Start()
    {
        AudioManager.instance.PlayMenuBGM();
    }

    public void OnButtonClick()
    {
        AudioManager.instance.PlayButtonClick();
    }

    public void OnStartGame()
    {
        OnButtonClick(); 
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OnSettings()
    {
        OnButtonClick(); 
        SceneManager.LoadScene("Settings");
    }

    public void OnQuit()
    {
        OnButtonClick();
        Application.Quit();
    }
}
