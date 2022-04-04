using UnityEngine;

public class playerInputs : MonoBehaviour
{
    private float speed = 12f;
    private Rigidbody2D rigidbody;
    public GameObject shootsObj;
    public Transform[] transformShootsExit;
    private float coolodwnShoot = 0f, speedShoot = 4f;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        repository.repositoryInScene.AddObject(shootsObj, 32);
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
        float mvX = Input.GetAxisRaw("Horizontal");

        rigidbody.velocity = Vector2.right * mvX * speed;

        if (Input.GetButtonDown("Shoot"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (coolodwnShoot <= 0f)
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
