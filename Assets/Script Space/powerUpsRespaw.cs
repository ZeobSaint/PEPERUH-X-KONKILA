using UnityEngine;

public class powerUpsRespaw : MonoBehaviour
{
    private float timeOftenAverage = 12f;
    private float posXVariation = 8f;
    public powerUpObt powerUpRespaw;
    private float timeCount = 0f, timeWait;

    // Start is called before the first frame update
    void Start()
    {
        repository.repositoryInScene.AddObject(powerUpRespaw.gameObject, 4);
        timeWait = timeOftenAverage;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hordersEnemies.horders.inCutscene)
        {
            if (timeCount >= timeWait)
            {
                timeCount = 0;
                timeWait = timeOftenAverage * Random.Range(0.5f, 1.5f);

                GameObject objRespaw = repository.repositoryInScene.GetObject(powerUpRespaw.gameObject);
                objRespaw.SetActive(true);
                Vector2 pos = Vector3.up * 12f;
                pos.x = Random.value * posXVariation;
                objRespaw.transform.position = pos;
            }
            else
            {
                timeCount += Time.deltaTime / hordersEnemies.horders.DifcultValue();
            }
        }
    }
}
