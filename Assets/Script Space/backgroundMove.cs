using UnityEngine;

public class backgroundMove : MonoBehaviour
{
    public Vector3 posVI, posVF;
    public float speed = 5f;
    private float countTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.localPosition = Vector3.Lerp(posVI, posVF, countTime);
        float dist = Vector3.Distance(posVI, posVF);
        float df = 1f;

        if (hordersEnemies.horders)
        {
            df = hordersEnemies.horders.DifcultValue();
        }

        countTime += Time.deltaTime * speed * df / dist;
        if (countTime >= 1f)
        {
            countTime -= 1f;
        }
    }
}
