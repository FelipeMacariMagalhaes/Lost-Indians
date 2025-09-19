using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;  
    public TextMeshProUGUI messageText; 
    public TextMeshProUGUI contadorText; 
    private float tempoMensagem;
    private float tempoContador;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        if (messageText.enabled && Time.time >= tempoMensagem)
        {
            messageText.enabled = false;
        }

        if (contadorText.enabled && Time.time >= tempoContador)
        {
            contadorText.enabled = false;
        }
    }

    public void ShowMessage(string message, float duration)
    {
        messageText.text = message;
        messageText.enabled = true;
        tempoMensagem = Time.time + duration;
    }

    // Método para atualizar o contador de livros 
    public void AtualizarContador(int quantidade, float duration = 10f)
    {
        if (contadorText != null)
        {
            contadorText.text = "Livros coletados: " + quantidade;
            contadorText.enabled = true;
            tempoContador = Time.time + duration;
        }
    }
}