using UnityEngine;
 
[RequireComponent(typeof(Rigidbody2D))]

[RequireComponent(typeof(Animator))]

public class Movi_2 : MonoBehaviour

{

    public float moveSpeed = 5f;

    public float jumpForce = 10f;

    private Rigidbody2D rb;

    private Animator anim;

    private bool isGrounded;
 
    public Transform groundCheck;

    public float groundCheckRadius = 0.2f;

    public LayerMask groundLayer;
 bool IsJumping = false;
    

    bool IsJuping = false;
   
    public Mode_universal modes;
 
    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

    }
 
    void Update()

    {

        Move();

        Jump();       

    }
 
    void Move()

    {

        float h = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(h * moveSpeed, rb.linearVelocity.y);
        

        if (h > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetFloat("Horizontal", h);
        }           

        else if (h < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetFloat("Horizontal", h);
        }
       

    }

    void Jump()
{
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    if (Input.GetButtonDown("Jump") && isGrounded)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);       
    }
}



 
    void OnDrawGizmosSelected()

    {

        if (groundCheck != null)

        {

            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        }

    }

}

 