using UnityEngine;

public class MoveTopDown : MonoBehaviour
{
    public float speed = 5f;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(h, v, 0) * speed * Time.deltaTime);

        anim.SetFloat("Horizontal", h);
        anim.SetFloat("Vertical", v);
    }
}