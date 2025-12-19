using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public AudioMixer mixer;

    public AudioClip menuBGM;
    public AudioClip gameBGM;

    public AudioClip buttonClickSFX;
    public AudioClip interactSFX;
    public AudioClip gameOverSFX;
    public AudioClip gameWinSFX;
    public AudioClip pauseSFX;
    public AudioClip resumeSFX;
    public AudioClip pipeSFX;
    public AudioClip walkingSFX;
    public AudioClip walkingOnSnowSFX;
    public AudioClip dogBark;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip && bgmSource.isPlaying) return;
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlayMenuBGM()
    {
        PlayBGM(menuBGM);
    }

    public void PlayGameBGM()
    {
        PlayBGM(gameBGM);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayButtonClick()
    {
        PlaySFX(buttonClickSFX);
    }

    public void PlayInteractSound()
    {
        PlaySFX(interactSFX);
    }

    public void PlayGameOverSound()
    {
        PlaySFX(gameOverSFX);
    }

    public void PlayGameWinSound()
    {
        PlaySFX(gameWinSFX);
    }

    public void PlayPauseSound()
    {
        PlaySFX(pauseSFX);
    }

    public void PlayResumeSound()
    {
        PlaySFX(resumeSFX);
    }

    public void PlayPipeSound()
    {
        PlaySFX(pipeSFX);
    }

    public void PlayWalkingSound()
    {
        PlaySFX(walkingSFX);
    }

    public void PlayWalkingOnSnowSound()
    {
        PlaySFX(walkingOnSnowSFX);
    }

    public void PlayDogBarkSound()
    {
        PlaySFX(dogBark);
    }
}
