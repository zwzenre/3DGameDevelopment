using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    private void Start()
    {
        if (AudioManager.instance == null)
        {
            Debug.LogWarning("AudioManager instance not found in scene!");
            return;
        }

        float masterVol = PlayerPrefs.GetFloat("MasterVolume", 0f);
        AudioManager.instance.mixer.SetFloat("MasterVolume", masterVol);
        Debug.Log("Loaded Master Volume: " + masterVol);

        float bgmVol = PlayerPrefs.GetFloat("BGMVolume", -10f);
        AudioManager.instance.mixer.SetFloat("BGMVolume", bgmVol);
        Debug.Log("Loaded BGM Volume: " + bgmVol);

        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", -10f);
        AudioManager.instance.mixer.SetFloat("SFXVolume", sfxVol);
        Debug.Log("Loaded SFX Volume: " + sfxVol);
    }

    public void OnButtonClick()
    {
        AudioManager.instance.PlayButtonClick();
    }

    public void BackToMenu()
    {
        OnButtonClick();
        SceneManager.LoadScene("Menu");
    }
}
