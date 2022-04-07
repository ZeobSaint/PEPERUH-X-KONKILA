using UnityEngine;

public class laserScript : MonoBehaviour
{
    public Vector2 sizefinal = Vector2.zero;
    [Min(0f)]
    public float timeMaxSize = 1f;
    private float countTime = 0f;
    private bool disable = false;
    private SpriteRenderer sprRenderer;
    private BoxCollider2D coll2D;

    // Start is called before the first frame update
    void Awake()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        coll2D = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        countTime = 0f;
        sprRenderer.size = Vector2.right * sizefinal.x;
        Vector2 sizeC = sprRenderer.size;
        sizeC.x = coll2D.size.x;
        coll2D.size = sizeC;
        disable = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countTime > 1f)
        {
            if (disable)
            {
                gameObject.SetActive(false);
            }
            {
                disable = true;
                countTime = 0f;
            }
        }
        else
        {
            countTime += Time.fixedDeltaTime / timeMaxSize;
            if (disable)
            {
                Vector2 sizeAux = Vector2.Lerp(Vector2.right * sizefinal.x, sizefinal, 1f-countTime);
                sprRenderer.size = sizeAux;
                Vector3 posAux = Vector3.down * sizefinal.y * countTime;
                transform.localPosition = posAux;
            }
            else
            {
                Vector2 sizeAux = Vector2.Lerp(Vector2.right * sizefinal.x, sizefinal, countTime);
                sprRenderer.size = sizeAux;
            }

            Vector2 sizeC = sprRenderer.size;
            sizeC.x = coll2D.size.x;
            coll2D.size = sizeC;
            coll2D.offset = Vector2.down * sizeC.y / 2f;
        }
    }
}
