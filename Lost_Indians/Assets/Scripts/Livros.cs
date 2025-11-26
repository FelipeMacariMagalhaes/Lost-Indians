
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Livros : CountBooks
{
    public Mode_universal mode_Universal;

    public Transform Player;
    bool flashOn = false;
    public UnityEvent Flashbacks;
    public UnityEvent NonFlashBacks;
    public Transform Teleport_flashOut;    
   
    void Start()
    {
        if (!flashOn)
        {
            NonFlashBacks.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {           
            Player.transform.position = Teleport_flashOut.transform.position;
            Flashbacks.Invoke();
            flashOn = true;
            mode_Universal.modoAtivo = 1;
            mode_Universal.AtualizarMovimentacao();
           
        }
    }
}
    /*public Transform Player;
    bool flashOn = false;
    public UnityEvent Flashbacks;
    public UnityEvent NonFlashBacks;
    public Troca_player_TopDown player_TopDown;
    public Troca_playerPlataform player_Plataform;
    public MoveTopDown moviTopDown;
    public Movi_2 movi_Plataform;
    private void Start()
    {
        CollectMessage = "Você Coletou Um livro";
        if (flashOn == false)
        {
            NonFlashBacks.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !player_Plataform.plataform)
        {
            Flashbacks.Invoke();
            player_TopDown.topDown = false;
            player_Plataform.plataform = true;
            player_TopDown.Update_Player();
            flashOn = true;
            transform.localScale = new Vector2(13, 5);
        }       
    }    
}
*/
/* using System;
using UnityEngine;
using UnityEngine.Events;

public class Livros : CountBooks
{
    public Transform Player;

   
    public UnityEvent Flashbacks;
    public UnityEvent NonFlashBacks;

   
    public MonoBehaviour[] movementScripts;
   
    public int modoAtivo = 0; // 0 = TopDown, 1 = Plataforma, etc.

    private bool flashOn = false;

    private void Start()
    {
        CollectMessage = "Você Coletou um livro";

        if (!flashOn)
        {
            NonFlashBacks.Invoke();
        }

        AtualizarMovimentacao();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Flashbacks.Invoke();
            flashOn = true;
            transform.localScale = new Vector2(13, 5);

            // alterna entre modos (exemplo simples)
            modoAtivo++;
            if (modoAtivo >= movementScripts.Length)
                modoAtivo = 0;

            AtualizarMovimentacao();
        }
    }

    private void AtualizarMovimentacao()
    {
        // desativa todos
        for (int i = 0; i < movementScripts.Length; i++)
        {
            if (movementScripts[i] != null)
                movementScripts[i].enabled = (i == modoAtivo);
        }
    }
}
*/
    





