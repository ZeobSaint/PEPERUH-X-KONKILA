using UnityEngine;

public class makeSoundWhenDisable : MonoBehaviour
{
    public AudioClip clip;
    private bool triggerCanGo = false;

    private void Start()
    {
        triggerCanGo = true;
    }

    private void OnDisable()
    {
        if (triggerCanGo && audioSourseRepository.sourseAudioRepository && enabled)
        {
            audioSourseRepository.sourseAudioRepository.GetAudioSource().PlayOneShot(clip);
        }
        //enabled = true;
    }
}
