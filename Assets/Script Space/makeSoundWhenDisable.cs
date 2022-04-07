using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (triggerCanGo && SceneManager.sceneCount == 1 && audioSourseRepository.sourseAudioRepository && enabled)
        {
            audioSourseRepository.sourseAudioRepository.GetAudioSource().PlayOneShot(clip);
        }
        //enabled = true;
    }
}
