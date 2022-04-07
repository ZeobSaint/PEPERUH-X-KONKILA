using UnityEngine;

public class shootIABoss : shootIA
{
    public GameObject laserObjt;
    public Transform transformLaserExit;

    protected override void Start()
    {
        base.Start();

        repository.repositoryInScene.AddObject(laserObjt, 4);
    }

    public override void Shoot()
    {
        if (cooldownShoot <= 0f)
        {
            if (1f / 8f > Random.value)
            {
                GetComponent<Animator>().SetTrigger("laser");
            }
            else
            {
                base.Shoot();
            }
        }
    }

    public void LaserFunction()
    {
        GameObject lzr = repository.repositoryInScene.GetObject(laserObjt);
        lzr.SetActive(true);
        lzr.transform.SetParent(transformLaserExit);
        lzr.transform.localPosition = Vector3.zero;
    }
}
