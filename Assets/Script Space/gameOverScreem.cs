using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScreem : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            enabled = false;
            SceneManager.LoadSceneAsync(0);
        }
    }

}
