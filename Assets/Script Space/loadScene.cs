using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public string nameSceneLoad;

    public void LoadScene()
    {
        if (enabled)
        {
            SceneManager.LoadSceneAsync(nameSceneLoad);
            enabled = false;
        }
    }
}
