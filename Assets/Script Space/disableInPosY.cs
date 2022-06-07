using UnityEngine;

public class disableInPosY : MonoBehaviour
{
    private float posYDisable = -5f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= posYDisable)
        {
            gameObject.SetActive(false);
        }
    }
}
