using UnityEngine;

public class MoveTopDown : MonoBehaviour
{
    [Header("Configurações")]
    public float moveSpeed = 5f;

    private Vector2 movement;
    public Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer n existe");
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("Animator n existe");
            }
        }
    }

    void Update()
    {
        //Input de move
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(horizontal, vertical).normalized;
        //Animator
        bool isMoving = movement != Vector2.zero;
        animator.SetBool("EstaMovendo", isMoving);
        animator.SetFloat("MoveEixoX", movement.x);
        animator.SetFloat("MoveEixoY", movement.y);

        if (isMoving)
        {
            animator.SetFloat("LastMoveX", movement.x);
            animator.SetFloat("LastMoveY", movement.y);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
