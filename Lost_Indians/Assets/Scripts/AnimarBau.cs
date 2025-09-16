using UnityEngine;

public class AnimarBau : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private bool jogadorPerto = false;
    private bool jaAbriu = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (jogadorPerto && !jaAbriu && Input.GetKeyDown(KeyCode.E))
        {
            AbrirBau();
        }
    }

    void AbrirBau()
    {
        if (jaAbriu) return;
        jaAbriu = true;
        if (animator != null)
        {
            animator.SetTrigger("Abrir");
        }
        if (audioSource != null)
        {
            audioSource.Play();
        }
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

