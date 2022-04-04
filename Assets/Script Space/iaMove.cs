using UnityEngine;

public class iaMove : MonoBehaviour
{
    private static float posXMin = -8f, posXMax = 8f;
    [Min(0f)]
    public float speed = 2f, moveY = 1f;
    private Rigidbody2D rigidbody;
    private float posYGo;
    private bool rightMove = true, moveVertical = false;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rightMove = true;
        moveVertical = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 posNow = transform.position;
        Vector2 direGo = Vector2.zero;

        if (moveVertical)
        {
            if (posNow.y <= posYGo)
            {
                direGo.y = 0f;
                rightMove = !rightMove;
                moveVertical = false;
                if (rightMove)
                {
                    direGo.x = 1f;
                }
                else
                {
                    direGo.x = -1f;
                }
            }
            else
            {
                direGo.y = -1f;
            }
        }
        else
        {
            if (rightMove)
            {
                if (posNow.x >= posXMax)
                {
                    moveVertical = true;
                    posYGo = posNow.y - moveY;
                    if (posYGo < 0f)
                    {
                        posYGo = 0f;
                    }
                    direGo.x = 0f;
                    direGo.y = -1f;
                }
                else
                {
                    direGo.x = 1f;
                }
            }
            else
            {
                if (posNow.x <= posXMin)
                {
                    moveVertical = true;
                    posYGo -= moveY;
                    if (posYGo < 0f)
                    {
                        posYGo = 0f;
                    }
                    direGo.x = 0f;
                    direGo.y = -1f;
                }
                else
                {
                    direGo.x = -1f;
                }
            }
        }

        float horderCount = hordersEnemies.horders.HorderNumber();
        horderCount -= 1f;
        float multSpd = 1f + (horderCount / (horderCount + 10f));

        rigidbody.velocity = direGo*speed*multSpd;
    }
}
