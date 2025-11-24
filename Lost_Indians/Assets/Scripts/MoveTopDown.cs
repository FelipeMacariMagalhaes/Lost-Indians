using UnityEngine;

public class MoveTopDown : MonoBehaviour
{
    [Header("Configurações")]
    public float moveSpeed = 5f;
    public float ladderSpeed = 2.5f;//velocidade na escada
    private float currentSpeed;
    private Vector2 movement;
    public Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool onLadder = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (onLadder)
        {
            movement = new Vector2(0, vertical).normalized;
            currentSpeed = ladderSpeed;
        }
        else
        {
            movement = new Vector2(horizontal, vertical).normalized;
            currentSpeed = moveSpeed;// volta para a velo normal
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Escada"))
        {
            onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Escada"))
        {
            onLadder = false;
        }
    }
}
