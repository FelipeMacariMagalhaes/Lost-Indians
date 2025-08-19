using UnityEngine;

public class InteraçaoComNPCs : MonoBehaviour
{
    
    
    public string mensagem = "Olá, viajante! Bem-vindo ao meu vilarejo!";

    private bool jogadorPerto = false;

    void Update()
    {
       
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            Interagir();
        }
    }

    private void Interagir()
    {
        
        Debug.Log(mensagem);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            Debug.Log("Pressione 'E' para falar com o NPC.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            Debug.Log("Você se afastou do NPC.");
        }
    }
}

