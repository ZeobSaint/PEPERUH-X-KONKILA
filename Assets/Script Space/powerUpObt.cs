using UnityEngine;

public class powerUpObt : MonoBehaviour
{
    public AudioClip clipGet;
    public Sprite[] spritePowers = new Sprite[3];
    private playerInputs.powerUp power = playerInputs.powerUp.notHas;
    private float duration = 0f;

    private void OnEnable()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        renderer.sprite = spritePowers[2];

        float aux = Random.value;

        power = playerInputs.powerUp.confused;

        if (aux > 2f / 3f)
        {
            renderer.sprite = spritePowers[1];
            power = playerInputs.powerUp.shield;
            duration = 12f;
        }
        else if (aux > 1f / 3f)
        {
            renderer.sprite = spritePowers[0];
            power = playerInputs.powerUp.rapidFire;
            duration = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInputs player = collision.GetComponentInParent<playerInputs>();

        if (player)
        {
            player.SetPowerUp(power, duration);

            gameObject.SetActive(false);

            if (clipGet)
            {
                audioSourseRepository.sourseAudioRepository.GetAudioSource().PlayOneShot(clipGet);
            }
        }
    }
}
