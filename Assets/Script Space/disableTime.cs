using UnityEngine;

public class disableTime : MonoBehaviour
{
    [Min(0f)]
    public float lifeTime = 5f;
    private float countTime = 0f;

    private void OnEnable()
    {
        countTime = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countTime >= lifeTime)
        {
            gameObject.SetActive(false);
        }
        else
        {
            countTime += Time.fixedDeltaTime;
        }
    }
}
