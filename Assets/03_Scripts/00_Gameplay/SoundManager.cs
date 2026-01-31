using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; 

    [Header("Background Music")]
    public AudioSource bgMusic;

    [Header("Sound Effects")]
    public AudioSource sfxSource;

    public AudioClip PushClip;
    public AudioClip CorrectClip;
    public AudioClip MoveClip;
    public AudioClip CompleteClip;

    private void Awake()
    {
        
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // tetap ada di scene lain
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Fungsi untuk memutar efek suara
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    // Fungsi untuk memutar musik
    public void PlayBGM(AudioClip clip)
    {
        bgMusic.clip = clip;
        bgMusic.Play();
    }

    // Fungsi untuk stop musik
    public void StopBGM()
    {
        bgMusic.Stop();
    }
}
