using UnityEngine;

public class Mode_universal : MonoBehaviour
{
    public Troca_player_TopDown player_TopDown;
    public Troca_playerPlataform player_Plataform;
    public MoveTopDown moviTopDown;
    public Movi_2 movi_Plataform;
    
    public MonoBehaviour[] plataform_Active;
    public MonoBehaviour[] topDown_Active;

    public int modoAtivo = 0;

    private void Start()
    {
        AtualizarMovimentacao();
    }

    public void TrocarModo(int novoModo)
    {
        if (novoModo == modoAtivo) return; // evita trocas desnecessárias
        modoAtivo = novoModo;
        AtualizarMovimentacao();
    }

    public void AtualizarMovimentacao()
    {
        bool isTopDown = (modoAtivo == 0);
        moviTopDown.enabled = isTopDown;
        movi_Plataform.enabled = !isTopDown;
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
