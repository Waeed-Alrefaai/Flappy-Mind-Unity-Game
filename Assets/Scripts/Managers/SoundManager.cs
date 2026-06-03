using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundSound;
    public AudioClip hitSound;
    public AudioClip gameOverSound;
    public AudioClip winSound;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        PlayBackground();
    }

    public void PlayBackground()
    {
        musicSource.clip = backgroundSound;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayHit()
    {
        sfxSource.PlayOneShot(hitSound);
    }

    public void PlayGameOver()
    {
        sfxSource.PlayOneShot(gameOverSound);
    }

    public void PlayWin()
    {
        sfxSource.PlayOneShot(winSound);
    }
}
