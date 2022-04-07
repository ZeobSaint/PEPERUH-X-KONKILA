using UnityEngine;

public class damageArea : MonoBehaviour
{
    public bool destroyerAfterImpact = true;
    public int damage = 1;
    public GameObject hitResapw;

    private void Start()
    {
        if (hitResapw)
        {
            repository.repositoryInScene.AddObject(hitResapw, 32);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hit = true;
        lifesScript lifes = collision.gameObject.GetComponent<lifesScript>();

        if (CompareTag(collision.tag) || hordersEnemies.horders.inCutscene)
        {
            hit = false;
        }

        if(lifes)
        {
            if (!lifes.CompareTag(tag))
            {
                lifes.AddHp(-damage);
            }
            
        }

        if (destroyerAfterImpact && hit)
        {
            gameObject.SetActive(false);
            if (hitResapw)
            {
                GameObject objX = repository.repositoryInScene.GetObject(hitResapw);
                objX.SetActive(true);
                Vector3 pos = (collision.bounds.center + GetComponent<Collider2D>().bounds.center) / 2f;
                objX.transform.position = pos;
            }
        }
    }
}
