using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenu;
    public CanvasGroup canvasGroup;
    public PlayerController playerController;
    public float fadeDuration = 1f;

    bool hasWon = false;

    public void ShowWinMenu()
    {
        if (hasWon) return;
        hasWon = true;

        winMenu.SetActive(true);
        StartCoroutine(FadeIn());

        Time.timeScale = 0f;
        if (playerController != null)
            playerController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        PlayWinSound();
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    void PlayWinSound()
    {
        AudioManager.instance.PlayGameBGM(); // or PlayWinSound() if you have one
    }
}