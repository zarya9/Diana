using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic;

    private bool isPlaying = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPlaying)
            {
                backgroundMusic.Pause();
                Debug.Log("Music Paused");
            }
            else
            {
                backgroundMusic.Play();
            }

            isPlaying = !isPlaying;
        }
    }
}