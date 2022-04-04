using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScreem : MonoBehaviour
{
    private float timeCount = 0f;


    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (timeCount >= 5f)
        {
            enabled = false;
            SceneManager.LoadSceneAsync(0);
        }
        else
        {
            timeCount += Time.unscaledDeltaTime;
        }
    }

}
