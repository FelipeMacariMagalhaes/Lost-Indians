using UnityEngine;

public class Tentativas : MonoBehaviour
{
    public int tentativasMaximas = 3;
    private int tentativasRestantes;
    public Text textoTentativas; 

    void Start()
    {
        tentativasRestantes = tentativasMaximas;
        AtualizarTextoTentativas();
    }

    public void DiminuirTentativas()
    {
        tentativasRestantes--;
        AtualizarTextoTentativas();

        if (tentativasRestantes <= 0)
        {
            
            Debug.Log("Sem tentativas restantes!");
            
        }
    }

    void AtualizarTextoTentativas()
    {
        textoTentativas.text = "Tentativas: " + tentativasRestantes;
    }

    
    public void ResetarTentativas()
    {
        tentativasRestantes = tentativasMaximas;
        AtualizarTextoTentativas();
    }
}
}
