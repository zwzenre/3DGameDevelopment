using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutScene : MonoBehaviour
{
    public enum CutsceneType
    {
        Intro,
        Ending
    }

    public CutsceneType cutsceneType;

    public PlayableDirector playableDirector;

    public Image fadeImage;
    public float fadeDuration = 1f;

    public string sceneToLoad;   // used only for Intro cutscene

    public WinMenu winMenu;      // used only for Ending cutscene

    public GameObject skipHintUI;

    private bool hasEnded = false;
    private bool isSkipping = false;

    void Start()
    {
        AudioManager.instance.PlayGameBGM();

        fadeImage.color = new Color(0, 0, 0, 1f);
        StartCoroutine(FadeIn());

        if (playableDirector != null)
        {
            playableDirector.stopped += OnTimelineEnd;
            playableDirector.Play();
        }
    }

    void Update()
    {
        if (hasEnded) return;

        if (Input.GetKeyDown(KeyCode.Space) && !isSkipping)
        {
            SkipCutscene();
        }
    }

    void OnDestroy()
    {
        if (playableDirector != null)
            playableDirector.stopped -= OnTimelineEnd;
    }

    void SkipCutscene()
    {
        isSkipping = true;

        if (playableDirector != null)
            playableDirector.Stop();

        StartCoroutine(EndCutsceneFlow());
    }

    void OnTimelineEnd(PlayableDirector director)
    {
        if (hasEnded) return;
        StartCoroutine(EndCutsceneFlow());
    }

    IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, Mathf.Lerp(1f, 0f, t / fadeDuration));
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 0f);
    }

    IEnumerator EndCutsceneFlow()
    {
        hasEnded = true;

        if (skipHintUI != null)
            skipHintUI.SetActive(false);

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, Mathf.Lerp(0f, 1f, t / fadeDuration));
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 1f);

        yield return new WaitForSecondsRealtime(0.3f);

        // 🔀 BRANCH HERE
        if (cutsceneType == CutsceneType.Intro)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else if (cutsceneType == CutsceneType.Ending)
        {
            if (winMenu != null)
                winMenu.ShowWinMenu();
        }
    }
}