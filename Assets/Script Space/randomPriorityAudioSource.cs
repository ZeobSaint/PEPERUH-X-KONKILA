using UnityEngine;

public class randomPriorityAudioSource : MonoBehaviour
{
    public int ranMin = 64, ranMax = 128;
    private void OnEnable()
    {
        GetComponent<AudioSource>().priority = Random.Range(ranMin, ranMax);
    }
}
