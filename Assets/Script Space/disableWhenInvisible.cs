using UnityEngine;

public class disableWhenInvisible : MonoBehaviour
{
    Renderer rendererHere;

    // Start is called before the first frame update
    void Awake()
    {
        rendererHere = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rendererHere.isVisible)
        {
            gameObject.SetActive(false);
        }
    }
}
