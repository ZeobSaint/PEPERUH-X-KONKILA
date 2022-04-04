using UnityEngine;

public class damageArea : MonoBehaviour
{
    public bool destroyerAfterImpact = true;
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hit = true;
        lifesScript lifes = collision.gameObject.GetComponent<lifesScript>();

        if (CompareTag(collision.tag))
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
        }
    }
}
