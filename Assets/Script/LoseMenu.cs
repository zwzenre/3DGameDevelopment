using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseMenu;
    public CanvasGroup canvasGroup;
    public PlayerController playerController;
    public float fadeDuration = 1f;
    bool hasLost = false;

    public void ShowLoseMenu()
    {
        if (hasLost) return;
            hasLost = true;

        loseMenu.SetActive(true);
        StartCoroutine(FadeIn());
        Time.timeScale = 0f; 
        playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        canvasGroup.alpha = 0f;

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

    public void Retry()
    {
        Time.timeScale = 1f;

        if (playerController != null)
            playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}