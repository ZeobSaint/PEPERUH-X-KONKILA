using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hordersEnemies : MonoBehaviour
{
    public static hordersEnemies horders = null;
    [HideInInspector]
    public bool inCutscene = false;
    public Transform transformHorder1, transformHorder2, transformHorder3;
    private iaMove[] enemiesArray1, enemiesArray2, enemiesArray3;
    private List<iaMove> enemiesInHorderNow = new List<iaMove>();
    public Text textHorder;
    private int countHorder = 0;
    private float respawCooldown = 0f;
    private bool trigger = false;
    public iaMove bossMv;
    public GameObject bossLife;
    public lifesScript player;
    private float countTimePlayerDead = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1f;

        horders = this;

        enemiesArray1 = transformHorder1.GetComponentsInChildren<iaMove>();
        enemiesArray2 = transformHorder2.GetComponentsInChildren<iaMove>();
        enemiesArray3 = transformHorder3.GetComponentsInChildren<iaMove>();

        bossMv.gameObject.SetActive(false);

        for (int i = 0; i < enemiesArray1.Length; i++)
        {
            enemiesArray1[i].gameObject.SetActive(false);
            enemiesArray2[i].gameObject.SetActive(false);
            enemiesArray3[i].gameObject.SetActive(false);
        }
    }

    private void AttHorder()
    {
        textHorder.text = "Horde " + countHorder;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.gameObject.activeInHierarchy)
        {
            if (countHorder < 5)
            {
                if (!enemiesInHorderNow.Exists(x => x.gameObject.activeInHierarchy))
                {
                    if (respawCooldown > 3f)
                    {
                        countHorder += 1;
                        if (countHorder < 5)
                        {
                            if (countHorder > 1)
                            {
                                float horderCount = hordersEnemies.horders.HorderNumber();
                                horderCount -= 2f;
                                float multScore = DifcultValue();
                                float addX = 130f * multScore;
                                scorePlayer.instance.AddScore((int)addX);
                                player.AddHp(1);
                            }

                            enemiesInHorderNow.Clear();

                            iaMove[] iaMovesArray = enemiesArray1;

                            if (countHorder == 2)
                            {
                                iaMovesArray = enemiesArray2;
                            }
                            else if (countHorder == 3)
                            {
                                iaMovesArray = enemiesArray3;
                            }
                            else if (countHorder == 4)
                            {
                                iaMovesArray = new iaMove[1];
                                iaMovesArray[0] = bossMv;
                                bossLife.SetActive(true);
                            }


                            for (int i = 0; i < iaMovesArray.Length; i++)
                            {
                                iaMovesArray[i].gameObject.SetActive(true);
                                enemiesInHorderNow.Add(iaMovesArray[i]);
                            }

                            respawCooldown = 0f;
                            AttHorder();

                            iaMove.multSpd = 3f;
                            inCutscene = true;
                            trigger = true;
                        }
                        else
                        {
                            bossLife.SetActive(false);
                            SceneManager.LoadSceneAsync("Victory Scene");
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
                        if (!enemiesInHorderNow.Exists(x => !x.IsStoped()))
                        {
                            inCutscene = false;
                            iaMove.multSpd = 1f;
                        }
                    }
                }
            }
        }
        else
        {
            if (countTimePlayerDead < 3f)
            {
                countTimePlayerDead += Time.deltaTime;
            }
            else
            {
                SceneManager.LoadSceneAsync("Game Over Scene");
                enabled = false;
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

    private void OnDestroy()
    {
        horders = null;
    }
}
