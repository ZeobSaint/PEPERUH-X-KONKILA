using UnityEngine;

public class makeSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    
    public void MakeTheSound()
    {
        audioSource.PlayOneShot(clip);
    }
}
