using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public TMP_Dropdown qualityDropdown;

    private float volume;
    private int qualityLevel;

    private void Start()
    {
        volume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        audioMixer.SetFloat("MasterVolume", volume);
        masterSlider.value = volume;

        volume = PlayerPrefs.GetFloat("BGMVolume", -10f);
        audioMixer.SetFloat("BGMVolume", volume);
        bgmSlider.value = volume;

        volume = PlayerPrefs.GetFloat("SFXVolume", -10f);
        audioMixer.SetFloat("SFXVolume", volume);
        sfxSlider.value = volume;

        qualityLevel = PlayerPrefs.GetInt("QualityLevel", QualitySettings.GetQualityLevel());

        QualitySettings.SetQualityLevel(qualityLevel);
        qualityDropdown.value = qualityLevel;
    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume", value);
        PlayerPrefs.Save();
        Debug.Log("Saved Master Volume: " + value);
    }

    public void SetBGMVolume(float value)
    {
        audioMixer.SetFloat("BGMVolume", value);
        PlayerPrefs.SetFloat("BGMVolume", value);
        PlayerPrefs.Save();
        Debug.Log("Saved BGM Volume: " + value);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", value);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
        Debug.Log("Saved SFX Volume: " + value);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        PlayerPrefs.SetInt("QualityLevel", index);
        PlayerPrefs.Save();
        Debug.Log("Saved Quality Index: " + index);
        Debug.Log("Saved Quality Name: " + QualitySettings.names[index]);
    }

}
