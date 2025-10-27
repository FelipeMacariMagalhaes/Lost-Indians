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
        bool isTopDown = (modoAtivo == 0);
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

        /* public void AtualizarMovimentacao()
         {
             bool isTopDown = (modoAtivo == 0);

             // Ativa um, desativa o outro
             moviTopDown.enabled = isTopDown;
             movi_Plataform.enabled = !isTopDown;
         }

         // Método auxiliar para alternar o modo diretamente
         public void TrocarModo(int novoModo)
         {
             modoAtivo = novoModo;
             AtualizarMovimentacao();
         }*/

        /*public void AtualizarMovimentacao()
        {      
                    if (modoAtivo == 0)
                    {
                        moviTopDown.enabled = true;
                        movi_Plataform.enabled = false;
                    }
                    else
                    {
                        moviTopDown.enabled = false;
                        movi_Plataform.enabled = true;
                    }

        }*/
    }
