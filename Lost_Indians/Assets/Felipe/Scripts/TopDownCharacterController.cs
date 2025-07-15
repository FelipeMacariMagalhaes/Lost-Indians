using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Cainos.Down_0_Basic
{

public class TopDownCharacterController : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("Direcao", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direcao", 3);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direcao", 3);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("Direcao", 0);
        }

        dir.Normalize();
        animator.SetBool("estaMovendo", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().linearVelocity = speed * dir;
    }
}
}
