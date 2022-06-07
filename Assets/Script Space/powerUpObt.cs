using UnityEngine;

public class powerUpObt : MonoBehaviour
{
    public AudioClip clipGet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInputs player = collision.GetComponentInParent<playerInputs>();

        if (player)
        {
            float duration = 8f;

            float aux = Random.value;

            playerInputs.powerUp power = playerInputs.powerUp.confused;

            if (aux > 2f / 3f)
            {
                power = playerInputs.powerUp.shield;
                duration = 12f;
            }
            else if (aux > 1f / 3f)
            {
                power = playerInputs.powerUp.rapidFire;
                duration = 4f;
            }

            player.SetPowerUp(power, duration);

            gameObject.SetActive(false);

            if (clipGet)
            {
                audioSourseRepository.sourseAudioRepository.GetAudioSource().PlayOneShot(clipGet);
            }
        }
    }
}
