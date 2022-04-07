using UnityEngine;
using UnityEngine.SceneManagement;

public class pressAnyButtonGoToScene : MonoBehaviour
{
    private float countTime=0f;
    [Min(0)]
    public float timeWait = 3f;
    public string scneneName;

    // Update is called once per frame
    void Update()
    {
        if (countTime >= 1f)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadSceneAsync(scneneName);
                enabled = false;
            }
        }
        else
        {
            countTime += Time.unscaledDeltaTime / timeWait;
        }
    }
}
