using UnityEngine;

public class playerInputs : MonoBehaviour
{
    public enum powerUp { rapidFire, shield, confused, notHas };
    private float speed = 12f;
    private Rigidbody2D rigidbody;
    public GameObject shootsObj;
    public Transform[] transformShootsExit;
    private float coolodwnShoot = 0f, speedShoot = 2.5f, rapidFireDuration = 0f, shieldDuration = 0f, confusedDuration = 0f;
    private bool autoMove = true;
    private Animator animator;
    [SerializeField]
    private Transform transformBarrier = null;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        repository.repositoryInScene.AddObject(shootsObj, 32);
        transform.position = Vector3.down * 6f;
    }

    public void SetPowerUp(powerUp power, float duration)
    {
        if(power == powerUp.rapidFire)
        {
            rapidFireDuration = duration;
        }
        else if(power == powerUp.shield)
        {
            shieldDuration = duration;
        }
        else if(power == powerUp.confused)
        {
            confusedDuration = duration;
        }
    }

    private void FixedUpdate()
    {
        if (coolodwnShoot > 0f)
        {
            coolodwnShoot -= Time.fixedDeltaTime * speedShoot;
        }

        if (confusedDuration > 0f)
        {
            confusedDuration -= Time.fixedDeltaTime;
        }

        if (rapidFireDuration > 0f)
        {
            rapidFireDuration -= Time.fixedDeltaTime;
        }

        if(shieldDuration > 0f)
        {
            shieldDuration -= Time.fixedDeltaTime;
        }

        if (shieldDuration > 0f)
        {
            if (!transformBarrier.gameObject.activeInHierarchy)
            {
                transformBarrier.gameObject.SetActive(true);
            }

            transformBarrier.localPosition = Vector3.up * 1.5f;
        }
        else if(transformBarrier.gameObject.activeInHierarchy)
        {
            transformBarrier.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (autoMove)
        {
            if (transform.position.y < 0f)
            {
                rigidbody.velocity = Vector2.up * speed;
            }
            else
            {
                rigidbody.velocity = Vector2.zero;
                autoMove = false;
            }
        }
        else
        {
            float mvX = Input.GetAxisRaw("Horizontal");

            if(confusedDuration > 0f)
            {
                mvX *= -1f;
            }

            rigidbody.velocity = Vector2.right * mvX * speed;

            if (rapidFireDuration > 0f)
            {
                Shoot();
            }
            else if (Input.GetButtonDown("Shoot"))
            {
                Shoot();
            }
        }

        if (rigidbody.velocity.x != 0f)
        {
            if (rigidbody.velocity.x > 0f)
            {
                if (transform.eulerAngles.y != 0f)
                {
                    Vector3 rot = transform.eulerAngles;
                    rot.y = 0f;
                    transform.eulerAngles = rot;
                }
            }
            else if (transform.eulerAngles.y != 180f)
            {
                Vector3 rot = transform.eulerAngles;
                rot.y = 180f;
                transform.eulerAngles = rot;
            }

            if (!animator.GetBool("isTurn"))
            {
                animator.SetBool("isTurn", true);
            }
        }
        else if (animator.GetBool("isTurn"))
        {
            animator.SetBool("isTurn", false);
        }
    }

    public void Shoot()
    {
        //Debug.Log(1);
        if (coolodwnShoot <= 0f && !hordersEnemies.horders.inCutscene)
        {
            GameObject obj = repository.repositoryInScene.GetObject(shootsObj);
            obj.SetActive(true);
            obj.tag = tag;
            obj.transform.position = transformShootsExit[0].position;
            progetilMove progetil = obj.GetComponent<progetilMove>();
            //progetil.extraForceX = rigidbody.velocity.x / 2f;
            progetil.SetDire(Vector2.up);
            if (rapidFireDuration > 0f)
            {
                coolodwnShoot = 0.5f;
            }
            else
            {
                coolodwnShoot = 1f;
            }
            //Debug.Log(coolodwnShoot);
        }
    }
}
