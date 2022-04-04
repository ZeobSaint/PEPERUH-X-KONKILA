using UnityEngine;
using UnityEngine.UI;

public class scorePlayer : MonoBehaviour
{
    public static scorePlayer instance;
    private int scoreNow = 0;
    public Text textScore;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        AddScore(0);
    }

    public void AddScore(int add)
    {
        scoreNow += add;
        textScore.text = "Pontos: " + scoreNow;
    }
}
