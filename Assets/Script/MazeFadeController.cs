using UnityEngine;
using System.Collections;

public class MazeFadeController : MonoBehaviour
{
    public static MazeFadeController instance;

    public CanvasGroup fadeCanvas;
    public float fadeDuration = 1f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            yield return null;
        }

        fadeCanvas.alpha = 0f;
    }

    // 🔥 NEW: Fade to black
    public IEnumerator FadeOut()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            yield return null;
        }

        fadeCanvas.alpha = 1f;
    }
}
