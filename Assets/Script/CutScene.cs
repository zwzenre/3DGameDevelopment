using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class CutScene : MonoBehaviour
{
    public string sceneToLoad;

    public Image fadeImage;
    public float fadeDuration = 1f;

    private bool isLoading = false;

    private void Start()
    {
        AudioManager.instance.PlayGameBGM();

        fadeImage.color = new Color(0, 0, 0, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isLoading)
        {
            nextScene();
        }
    }

    public void nextScene()
    {
        if (!isLoading)
        {
            StartCoroutine(LoadSceneWithFadeOut());
        }
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
