using UnityEngine;

public class playerInputs : MonoBehaviour
{
    private float speed = 12f;
    private Rigidbody2D rigidbody;
    public GameObject shootsObj;
    public Transform[] transformShootsExit;
    private float coolodwnShoot = 0f, speedShoot = 4f;
    private bool autoMove = true;
    private Animator animator;

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

    private void FixedUpdate()
    {
        if (coolodwnShoot > 0f)
        {
            coolodwnShoot -= Time.fixedDeltaTime * speedShoot;
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

            rigidbody.velocity = Vector2.right * mvX * speed;

            if (Input.GetButtonDown("Shoot"))
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
        if (coolodwnShoot <= 0f && !hordersEnemies.horders.inCutscene)
        {
            GameObject obj = repository.repositoryInScene.GetObject(shootsObj);
            obj.SetActive(true);
            obj.tag = tag;
            obj.transform.position = transformShootsExit[0].position;
            progetilMove progetil = obj.GetComponent<progetilMove>();
            //progetil.extraForceX = rigidbody.velocity.x / 2f;
            progetil.SetDire(Vector2.up);
            coolodwnShoot = 1f;
        }
    }
}
