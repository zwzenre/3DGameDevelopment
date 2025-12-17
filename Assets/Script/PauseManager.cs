using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
       isPaused = !isPaused;
       pausePanel.SetActive(isPaused);

       if (isPaused )
       {
            OnPauseClick();
       }
       else
       {
            OnResumeClick();
       }
       Time.timeScale = isPaused ? 0f : 1f;
       Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
       Cursor.visible = isPaused;
    }

    public void OnPauseClick()
    {
        AudioManager.instance.PlayPauseSound();
    }

    public void OnResumeClick()
    {
        AudioManager.instance.PlayResumeSound();
    }

    public void Resume()
    {
        OnResumeClick();
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitToMenu()
    {
        OnResumeClick();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
