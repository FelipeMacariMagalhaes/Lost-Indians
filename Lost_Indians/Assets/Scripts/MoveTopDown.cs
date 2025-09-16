using UnityEngine;

public class MoveTopDown : MonoBehaviour
{
    [Header("Configurações")]
    public float moveSpeed = 5f;

    private Vector2 movement;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontal, vertical).normalized;
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
