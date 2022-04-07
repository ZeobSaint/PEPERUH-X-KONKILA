using UnityEngine;

public class iaMove : MonoBehaviour
{
    public static float multSpd = 1f;
    private static float posXMin = -8f, posXMax = 8f;
    [Min(0f)]
    public float speed = 2f, moveY = 1f;
    private Rigidbody2D rigidbody;
    private float posYGo;
    private bool rightMove = true, moveVertical = false;
    public bool initialRightMove = true;
    [HideInInspector]
    public bool dontMoveHorizontal = false;
    [SerializeField]
    private bool dontMove = false;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rightMove = initialRightMove;
        moveVertical = true;
        dontMoveHorizontal = true;
        posYGo = transform.position.y - 6f;
    }

    public bool IsStoped()
    {
        //Debug.Log(rigidbody.velocity.sqrMagnitude);
        return rigidbody.velocity.sqrMagnitude == 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direGo = Vector2.zero;

        if (!dontMove)
        {
            if (!hordersEnemies.horders.inCutscene)
            {
                dontMoveHorizontal = false;
            }

            Vector2 posNow = transform.position;

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
                if (!dontMoveHorizontal)
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
                else
                {
                    direGo = Vector2.zero;
                }
            }
        }


        rigidbody.velocity = direGo * speed * hordersEnemies.horders.DifcultValue() * multSpd;
    }
}
