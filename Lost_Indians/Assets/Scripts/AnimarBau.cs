using UnityEngine;

public class AnimarBau : MonoBehaviour
{
        private Animator animator;
        private AudioSource audioSource;
        private bool jogadorPerto = false;
        private bool aberto = false;
        private bool JaAbriu;
        void Start()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            // Apertar E perto do baú
            if (jogadorPerto && !aberto && Input.GetKeyDown(KeyCode.E))
            {
                AbrirBau();
            }
        }

        void AbrirBau()
        {
            audioSource.Play();
            if (!JaAbriu) 
        {
               if (animator != null)
            {
                animator.SetTrigger("Abrir"); 
                JaAbriu = true; 
            }
        }
    }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                jogadorPerto = true;
            AbrirBau();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                jogadorPerto = false;
            AbrirBau();
        }
    }
