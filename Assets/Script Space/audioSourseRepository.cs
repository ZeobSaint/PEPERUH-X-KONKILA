using System.Collections.Generic;
using UnityEngine;

public class audioSourseRepository : MonoBehaviour
{
    public static audioSourseRepository sourseAudioRepository = null;
    public AudioSource audioSourceBase;
    private List<AudioSource> audioSourcesList = new List<AudioSource>();

    // Start is called before the first frame update
    void Awake()
    {
        sourseAudioRepository = this;

        for(int i = 0; i < 128; i++)
        {
            AudioSource adX =Instantiate(audioSourceBase);
            audioSourcesList.Add(adX);
            adX.priority = 64 + i;
            adX.transform.SetParent(transform);
        }
    }

    public AudioSource GetAudioSource()
    {
        AudioSource adX = audioSourcesList.Find(x => !x.isPlaying);

        if (!adX)
        {
            for(int i = 0; i < 32; i++)
            {
                adX = Instantiate(audioSourceBase);
                adX.priority = Random.Range(64, 192);
                audioSourcesList.Add(adX);
                adX.transform.SetParent(transform);
            }
        }

        adX.pitch = 1f;
        adX.loop = false;
        adX.volume = 1f;

        return adX;
    }
}
