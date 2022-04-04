using UnityEngine;
using UnityEngine.UI;

public class lifesScript : MonoBehaviour
{
    [Min(1)]
    public int hpMax = 1;
    private int hpNow;
    public Slider hpSlider;
    public float addScore = 10f;
    public gameOverScreem gameOver;

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
        hpNow += add;
        if (hpNow <= 0)
        {
            hpNow = 0;
            gameObject.SetActive(false);

            if (!CompareTag("Player"))
            {
                float horderCount = hordersEnemies.horders.HorderNumber();
                horderCount -= 1f;
                float multScore = 1f + (horderCount / (horderCount + 10f));
                float addX = addScore * multScore;
                scorePlayer.instance.AddScore(Mathf.CeilToInt(addX));
            }
            else if(gameOver)
            {
                gameOver.gameObject.SetActive(true);
            }
        }
        else if(hpNow> hpMax)
        {
            hpNow=hpMax;
        }

        if (hpSlider)
        {
            hpSlider.value = ((float)hpNow) / hpMax;
        }
    }
}
