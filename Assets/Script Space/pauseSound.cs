using UnityEngine;

public class pauseSound : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
        else if (audioSource.time != 0f)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.UnPause();
            }
        }
    }
}
