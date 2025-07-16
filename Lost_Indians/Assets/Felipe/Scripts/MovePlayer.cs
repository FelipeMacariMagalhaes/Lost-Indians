using UnityEngine;


using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;


public class MovePlayer : MonoBehaviour
{
    [Header("RigidBody do player")]
    [Tooltip("\"Corpo\" do personagem")]
    [SerializeField] Rigidbody2D rb;

    [Space(10)]

    [Header("Velocidade do Player")]
    [Tooltip("Variavel que controla a velocidade")]
    [SerializeField] float speed;

    [Space(10)]

    [Header("Força do Pulo do Player")]
    [Tooltip("Variavel que controla a força de salto")]
    [SerializeField] float jumpforce;

    [Space(10)]

    [Header("Tranform dos pés do player")]
    [Tooltip("Variavel que mostra a area de contato com o chão")]
    [SerializeField] Transform pointGround;

    [Space(10)]

    [Header("Layer da colisão com o chao")]
    [Tooltip("Variavel que indica em qual layer ele pode pular")]
    [SerializeField] LayerMask ground;

    [Space(10)]

    [Header("Animator do Player")]
    [Tooltip("Variavel controla o animator do player")]
    [SerializeField] Animator player;

    bool facingRight;
    bool grounded;
    float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Animator>();
    }

    #region movimentação do player
    public void Move()
    {
        //Movimentação do personagem
        grounded = Physics2D.OverlapCircle(pointGround.position, 0.3f, ground);

        horizontal = Input.GetAxisRaw("Horizontal");

        player.SetBool("isMoving", horizontal != 0);

        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        //Movimentação do personagem

        // Pulo do Personagem
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpforce;
            player.SetBool("Jump", true);
        }

        if (horizontal < 0 && !facingRight || horizontal > 0 && facingRight)
        {
            Flip(horizontal);
        }
        // Pulo do personagem
    }
    #endregion movimentação do player

    #region Flip do Player
    void Flip(float filme)
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    #endregion Flip do Player
}
