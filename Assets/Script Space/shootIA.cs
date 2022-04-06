using UnityEngine;

public class shootIA : MonoBehaviour
{
    private static int iAShootControll = 0;
    private static bool shootsCountTrigger = false;
    private static float cooldownShoot = 0f;
    public LayerMask layerObst;
    public GameObject shootObj;
    private float timeShoot = 0f;
    [Min(0f)]
    public float ofterShoot = 1f;
    public Transform[] transformShootsExit;
    private float shootTime;

    // Start is called before the first frame update
    void Start()
    {
        repository.repositoryInScene.AddObject(shootObj, 32);
        //shootTime = 0.5f + Random.value;
    }

    private void OnEnable()
    {
        shootTime = 0.5f + Random.value;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hordersEnemies.horders.inCutscene)
        {
            if (cooldownShoot > 0f && !shootsCountTrigger)
            {
                cooldownShoot -= Time.fixedDeltaTime;
                shootsCountTrigger = true;
            }

            if (timeShoot >= shootTime)
            {
                Shoot();
                timeShoot = 0f;
                shootTime = 0.5f + Random.value;
            }
            else
            {
                float multSpd = hordersEnemies.horders.DifcultValue();

                timeShoot += Time.fixedDeltaTime * ofterShoot * multSpd;
            }
        }
    }

    private void LateUpdate()
    {
        shootsCountTrigger = false;
    }

    public void Shoot()
    {
        if (cooldownShoot <= 0f)
        {
            int numbersShootMax = 3;
            int horderCount = hordersEnemies.horders.HorderNumber();

            if (horderCount >= 10)
            {
                numbersShootMax += 3;
            }
            else if (horderCount >= 6)
            {
                numbersShootMax += 2;
            }
            else if (horderCount >= 3)
            {
                numbersShootMax += 1;
            }

            Vector2 posOrg = transformShootsExit[0].transform.position + Vector3.down;
            RaycastHit2D hit2D = Physics2D.CircleCast(posOrg, 0.5f, Vector2.down, 20f, layerObst);

            if (!hit2D.collider)
            {
                GameObject obj = repository.repositoryInScene.GetObject(shootObj);
                obj.SetActive(true);
                obj.tag = tag;
                obj.transform.position = transformShootsExit[0].position;
                progetilMove progetil = obj.GetComponent<progetilMove>();
                progetil.extraForceX = GetComponent<Rigidbody2D>().velocity.x / 2f;
                progetil.SetDire(Vector2.down);
                iAShootControll += 1;
                if (iAShootControll >= numbersShootMax)
                {
                    cooldownShoot = 3f;
                    iAShootControll = 0;
                }
            }
        }
    }
}
