using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip backgroundMusic;

    void Start()
    {
        // Assign the audio clip to the source
        musicSource.clip = backgroundMusic;
        // Play the music
        musicSource.Play();
    }
}

