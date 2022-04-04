using UnityEngine;

public class progetilMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 18f;
    private Vector2 direGo;
    public float extraForceX = 0f;
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetDire(Vector2 dire)
    {
        direGo = dire;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horderCount = hordersEnemies.horders.HorderNumber();
        horderCount -= 1f;
        float multSpd = 1f + 2f*(horderCount / (horderCount + 10f));

        if(rigidbody.velocity != direGo * speed*multSpd)
        {
            rigidbody.velocity = (direGo * speed  + Vector2.right * extraForceX)* multSpd;
        }
    }
}
