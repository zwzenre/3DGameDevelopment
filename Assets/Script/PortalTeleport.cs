using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PortalTransition : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public CanvasGroup textCanvas;
    public float fadeDuration = 1f;
    public float textDelay = 0.5f;
    public string nextScene = "MazeScene";

    bool isTransitioning = false;

    void Start()
    {
        fadeCanvas.alpha = 0f;
        textCanvas.alpha = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isTransitioning) return;

        if (other.CompareTag("Player"))
        {
            isTransitioning = true;
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        float t = 0f;

        // Fade to black
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        fadeCanvas.alpha = 1f;

        yield return new WaitForSeconds(textDelay);

        textCanvas.alpha = 1f;

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(nextScene);
    }
}