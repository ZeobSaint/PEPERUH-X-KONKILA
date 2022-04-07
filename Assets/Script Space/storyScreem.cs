using UnityEngine;

public class storyScreem : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Shoot"))
        {
            animator.SetFloat("speed", 10f);
        }
        else
        {
            animator.SetFloat("speed", 1f);
        }
    }
}
