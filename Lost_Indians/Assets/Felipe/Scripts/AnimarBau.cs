using UnityEngine;

public class AnimarBau : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private bool jogadorPerto = false;
    private bool aberto = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (jogadorPerto && !aberto && Input.GetKeyDown(KeyCode.E))
        {
            AbrirBau();
        }
    }

    void AbrirBau()
    {
        aberto = true;
        animator.SetBool("Abrir", true);
        audioSource.Play();
        Invoke("PararSom", 5f);
    }

    void PararSom()
    {
        audioSource.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}

