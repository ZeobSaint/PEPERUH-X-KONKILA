using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public string nameSceneLoad;
    public AudioSource waitSound = null;
    private bool triggerLoadScene = false;

    public void LoadScene()
    {
        if (enabled && !triggerLoadScene)
        {
            if (waitSound)
            {
                triggerLoadScene = true;
            }
            else
            {
                SceneManager.LoadSceneAsync(nameSceneLoad);
                enabled = false;
            }
        }
    }

    private void LateUpdate()
    {
        if (triggerLoadScene)
        {
            if (!waitSound.isPlaying)
            {
                SceneManager.LoadSceneAsync(nameSceneLoad);
                enabled = false;
            }
        }
    }
}
