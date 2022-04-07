using UnityEngine;
using UnityEngine.UI;

public class lifesScript : MonoBehaviour
{
    [Min(1)]
    public int hpMax = 1;
    private int hpNow;
    public Slider hpSlider;
    public float addScore = 10f;
    public GameObject objResapwInDead, dropItem;

    private void Start()
    {
        if (objResapwInDead)
        {
            repository.repositoryInScene.AddObject(objResapwInDead, 32);
        }

        if (dropItem)
        {
            repository.repositoryInScene.AddObject(dropItem, 4);
        }
    }

    private void OnEnable()
    {
        hpNow = hpMax;
        if (hpSlider)
        {
            hpSlider.value = ((float)hpNow) / hpMax;
        }
    }

    public void AddHp(int add)
    {
        if (!(hordersEnemies.horders.inCutscene && add<0))
        {
            hpNow += add;
            if (hpNow <= 0)
            {
                hpNow = 0;
                gameObject.SetActive(false);

                if (objResapwInDead)
                {
                    GameObject objRespaw = repository.repositoryInScene.GetObject(objResapwInDead);
                    objRespaw.SetActive(true);
                    objRespaw.transform.position = transform.position;
                }

                if (dropItem && 1f / 8f > Random.value)
                {
                    GameObject objRespaw = repository.repositoryInScene.GetObject(dropItem);
                    objRespaw.SetActive(true);
                    objRespaw.transform.position = transform.position;
                }

                if (!CompareTag("Player"))
                {
                    float multScore = hordersEnemies.horders.DifcultValue();
                    float addX = addScore * multScore;
                    scorePlayer.instance.AddScore(Mathf.CeilToInt(addX));
                }
            }
            else if (hpNow > hpMax)
            {
                hpNow = hpMax;
            }

            if (hpSlider)
            {
                hpSlider.value = ((float)hpNow) / hpMax;
            }
        }
    }
}
