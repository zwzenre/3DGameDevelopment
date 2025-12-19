using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using System.Collections;

public class CutScene : MonoBehaviour
{
    [Header("Timeline")]
    public PlayableDirector playableDirector;

    [Header("Fade")]
    public Image fadeImage;
    public float fadeDuration = 1f;

    [Header("Win Menu")]
    public WinMenu winMenu;

    private bool hasEnded = false;
    private bool isSkipping = false;
    public GameObject skipHintUI;

    void Start()
    {
        AudioManager.instance.PlayGameBGM();

        // Start fully black
        fadeImage.color = new Color(0, 0, 0, 1f);

        // Fade in
        StartCoroutine(FadeIn());

        // Listen for timeline end
        if (playableDirector != null)
        {
            playableDirector.stopped += OnTimelineEnd;
            playableDirector.Play();
        }
    }

    void Update()
    {
        if (hasEnded) return;

        // SPACE to skip cutscene
        if (Input.GetKeyDown(KeyCode.Space) && !hasEnded && !isSkipping)
        {
            SkipCutscene();
        }
    }

    void OnDestroy()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnTimelineEnd;
        }
    }

    void OnTimelineEnd(PlayableDirector director)
    {
        if (hasEnded) return;
        hasEnded = true;

        StartCoroutine(FadeOutAndShowWinMenu());
    }

    void SkipCutscene()
    {
        isSkipping = true;

        if (playableDirector != null)
            playableDirector.Stop();

        StartCoroutine(FadeOutAndShowWinMenu());
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0f);
    }

    IEnumerator FadeOutAndShowWinMenu()
    {
        hasEnded = true;

        if (skipHintUI != null)
            skipHintUI.SetActive(false);
        
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 1f);

        yield return new WaitForSecondsRealtime(0.3f);

        if (winMenu != null)
        {
            winMenu.ShowWinMenu();
        }
    }
}