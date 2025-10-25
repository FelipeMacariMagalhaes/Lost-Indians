using UnityEngine;

public class Troca_playerPlataform : MonoBehaviour
{   
    public bool plataform = false;
    public Troca_player_TopDown player_TopDown;
    public Mode_universal mode_Universal;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mode_Universal.TrocarModo(0);
            /*mode_Universal.modoAtivo = 1;
            mode_Universal.AtualizarMovimentacao();*/
        }
    }
            /*void OnTriggerEnter2D(Collider2D other)
            {
              if(other.CompareTag("Player") && !plataform)
                {
                    player_TopDown.topDown = false;
                    plataform = true;           
                    player_TopDown.Update_Player();
                }
            }*/

}
