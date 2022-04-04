using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hordersEnemies : MonoBehaviour
{
    public static hordersEnemies horders = null;
    public List<GameObject> enemiesList = new List<GameObject>();
    private Vector3[] listPos;
    public Text textHorder;
    private int countHorder = 0;
    private float respawCooldown = 0f;


    // Start is called before the first frame update
    void Awake()
    {
        horders = this;
        listPos = new Vector3[enemiesList.Count];
        for(int i = 0; i < enemiesList.Count; i++)
        {
            listPos[i] =enemiesList[i].transform.position;
            enemiesList[i].SetActive(false);
        }
    }

    private void AttHorder()
    {
        textHorder.text = "Horda " + countHorder;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!enemiesList.Exists(x => x.activeInHierarchy))
        {
            if (respawCooldown > 3f)
            {
                countHorder += 1;

                if (countHorder > 1)
                {
                    float horderCount = hordersEnemies.horders.HorderNumber();
                    horderCount -= 2f;
                    float multScore = 1f + (horderCount / (horderCount + 10f));
                    float addX = 130f * multScore;
                    scorePlayer.instance.AddScore((int)addX);
                }

                respawCooldown = 0f;
                AttHorder();

                for(int i = 0; i < enemiesList.Count; i++)
                {
                    if (countHorder == 3 || countHorder == 6 || countHorder == 10)
                    {
                        enemiesList[i].GetComponent<lifesScript>().hpMax += 1;
                    }
                    enemiesList[i].SetActive(true);
                    enemiesList[i].transform.position = listPos[i];
                }
            }
            else
            {
                respawCooldown += Time.fixedDeltaTime;
            }
        }
    }

    public int HorderNumber()
    {
        return countHorder;
    }
}
