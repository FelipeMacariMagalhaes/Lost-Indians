using UnityEngine;

public class Troca_player_TopDown : MonoBehaviour
{
   
    public Troca_playerPlataform player_Plataform;
    public bool topDown = true;
    public MoveTopDown moviTopDown;
    public Movi_2 movi_Plataform;
    public Mode_universal mode_Universal;
    void Start()
    {

    }

    public int modoParaAtivar = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mode_Universal.TrocarModo(modoParaAtivar);
        }
    }
    /*void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mode_Universal.TrocarModo(1);*/
    /*mode_Universal.modoAtivo = 0;
    mode_Universal.AtualizarMovimentacao();*/
}

        /*void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag ("Player") && !topDown)
            {
                player_Plataform.plataform = false;
                topDown = true;            
                Update_Player();           
            }
        }

        public void Update_Player()
        {
            movi_Plataform.enabled = player_Plataform.plataform;
            moviTopDown.enabled = topDown;
        }*/
    

