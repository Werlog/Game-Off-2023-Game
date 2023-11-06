using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;

    public AudioClip[] sfxClips;
    public AudioClip[] musicClips;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    public float restartMusicDelay = 20f;
    private bool isMusicPlaying = false;
    private float timeSinceMusicStopped = 0f;

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

    private void Update()
    {
        if (!isMusicPlaying && !musicSource.isPlaying)
        {
            timeSinceMusicStopped += Time.deltaTime;
            if (timeSinceMusicStopped >= restartMusicDelay)
            {
                PlayRandomMusic();
                timeSinceMusicStopped = 0f;
            }
        }
        else
        {
            timeSinceMusicStopped = 0f;
        }
    }

    public void PlaySFX(int index)
    {
        if (index >= 0 && index < sfxClips.Length)
        {
            sfxSource.PlayOneShot(sfxClips[index]);
        }
    }

    public void PlayMusic(int index)
    {
        if (index >= 0 && index < musicClips.Length)
        {
            musicSource.clip = musicClips[index];
            musicSource.Play();
            isMusicPlaying = true;
        }
    }

    public void PlayRandomMusic()
    {
        int randomIndex = Random.Range(0, musicClips.Length);
        PlayMusic(randomIndex);
    }

    public void StopMusic()
    {
        musicSource.Stop();
        isMusicPlaying = false;
        timeSinceMusicStopped = 0f;
    }
}