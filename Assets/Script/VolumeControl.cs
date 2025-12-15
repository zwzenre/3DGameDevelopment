using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    private float volume;

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
}
