using UnityEngine;

public class Mode_universal : MonoBehaviour
{
   
    public MoveTopDown moviTopDown;
    public Movi_2 movi_Plataform;    
    public Rigidbody2D Rigidbody2D;

    public int modoAtivo = 0;

    private void Start()
    {
        AtualizarMovimentacao();
    }

    public void TrocarModo(int novoModo)
    {
        if (novoModo == modoAtivo) return; // evita trocas desnecessárias
        {
            modoAtivo = novoModo;
            AtualizarMovimentacao();
        }
    }

    public void AtualizarMovimentacao()
    {
        bool isTopDown = (modoAtivo == 0); // jogo de boleanas
        moviTopDown.enabled = isTopDown;
        movi_Plataform.enabled = !isTopDown;
        if(isTopDown == true)
        {
            Rigidbody2D.gravityScale = 0;
        }
        else 
        {
            Rigidbody2D.gravityScale = 1;
        }
    }       
    }
