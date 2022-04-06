using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hordersEnemies : MonoBehaviour
{
    public static hordersEnemies horders = null;
    [HideInInspector]
    public bool inCutscene = false;
    public List<iaMove> enemiesList = new List<iaMove>();
    private Vector3[] listPos;
    public Text textHorder;
    private int countHorder = 0;
    private float respawCooldown = 0f;
    private bool trigger = false;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1f;

        horders = this;
        listPos = new Vector3[enemiesList.Count];
        for (int i = 0; i < enemiesList.Count; i++)
        {
            listPos[i] = enemiesList[i].transform.position;
            enemiesList[i].gameObject.SetActive(false);
        }
    }

    private void AttHorder()
    {
        textHorder.text = "Horda " + countHorder;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!enemiesList.Exists(x => x.gameObject.activeInHierarchy))
        {
            if (respawCooldown > 3f)
            {
                countHorder += 1;

                if (countHorder > 4)
                {
                    countHorder = 4;
                }

                if (countHorder > 1)
                {
                    float horderCount = hordersEnemies.horders.HorderNumber();
                    horderCount -= 2f;
                    float multScore = DifcultValue();
                    float addX = 130f * multScore;
                    scorePlayer.instance.AddScore((int)addX);
                }

                respawCooldown = 0f;
                AttHorder();

                iaMove.multSpd = 3f;
                inCutscene = true;
                trigger = true;

                for (int i = 0; i < enemiesList.Count; i++)
                {
                    if (countHorder == 2)
                    {
                        enemiesList[i].GetComponent<lifesScript>().hpMax += 1;
                    }
                    else if(countHorder == 3)
                    {
                        enemiesList[i].GetComponent<lifesScript>().hpMax += 2;
                    }

                    enemiesList[i].transform.position = listPos[i];
                    enemiesList[i].gameObject.SetActive(true);
                }
            }
            else
            {
                respawCooldown += Time.fixedDeltaTime;
            }
        }
        else
        {
            if (trigger)
            {
                trigger = false;
            }
            else if (inCutscene)
            {
                if (!enemiesList.Exists(x => !x.IsStoped()))
                {
                    inCutscene = false;
                    iaMove.multSpd = 1f;
                }
            }
        }
    }

    public int HorderNumber()
    {
        return countHorder;
    }

    public float DifcultValue()
    {
        float horderCount = countHorder;

        switch (horderCount)
        {
            case 0:
                return 1f;
            case 1:
                return 1f;
            case 2:
                return 1.2f;
            case 3:
                return 1.5f;
            case 4:
                return 2f;

        }

        return 1f;
    }
}
