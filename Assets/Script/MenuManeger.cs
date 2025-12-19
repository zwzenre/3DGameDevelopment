using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public string sceneToLoad;

    public Image fadeImage;
    public float fadeDuration = 1f;

    private bool isLoading = false;

    private void Start()
    {
        AudioManager.instance.PlayMenuBGM();

        fadeImage.color = new Color(0, 0, 0, 0);
    }

    public void OnButtonClick()
    {
        AudioManager.instance.PlayButtonClick();
    }

    public void OnStartGame()
    {
        OnButtonClick();
        if (!isLoading)
        {
            StartCoroutine(LoadSceneWithFadeOut());
        }
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

    IEnumerator FadeOut()
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator LoadSceneWithFadeOut()
    {
        isLoading = true;
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(sceneToLoad);
    }
}
