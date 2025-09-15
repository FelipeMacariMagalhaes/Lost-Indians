using TMPro;
using UnityEngine;
using System.Collections;

public class GerenciadorDeDialogo : MonoBehaviour
{
    public GameObject painelDialogo;
    public TextMeshProUGUI textoNPC;
    public TextMeshProUGUI textoJogador;
    public GameObject painelEscolhas;

    public string[] falasNPC;
    public string[] falasJogador;

    public string[] falasPosBemNPC;
    public string[] falasPosBemJogador;
    public string[] falasPosMalNPC;
    public string[] falasPosMalJogador;
    
    public GameObject npcBruxa;

    private int indiceFala = 0;
    public bool dialogoAtivo = false;
    private bool esperandoEscolha = false;

    void Start()
    {
        painelDialogo.SetActive(false);
        painelEscolhas.SetActive(false);
        dialogoAtivo = false;
    }

    void Update()
    {
        if (dialogoAtivo && !esperandoEscolha && Input.GetKeyDown(KeyCode.Space))
        {
            AvancarFala();
        }
    }

    public void IniciarDialogo()
    {

        if (falasNPC.Length == 0 || falasJogador.Length == 0) return;

        indiceFala = 0;
        painelDialogo.SetActive(true);
        AtualizarFalas();
        dialogoAtivo = true;

        
    }

    void AvancarFala()
    {
        indiceFala++;

        if (indiceFala < falasNPC.Length && indiceFala < falasJogador.Length)
        {
            AtualizarFalas();

            if (indiceFala == falasNPC.Length - 1)
            {
                esperandoEscolha = true;
                Invoke(nameof(MostrarEscolhas), 2f);
            }
        }
        else if (!esperandoEscolha)
        {
           
        }
    }

    void AtualizarFalas()
    {
        textoNPC.text = falasNPC[indiceFala];
        textoJogador.text = falasJogador[indiceFala];
    }

    void MostrarEscolhas()
    {
        painelEscolhas.SetActive(true);
    }



    public void EscolherBem()
    {
        painelEscolhas.SetActive(false);
        esperandoEscolha = false;

        StartCoroutine(MostrarFalasAlternadas(falasPosBemNPC, falasPosBemJogador));
    }

    public void EscolherMal()
    {
        painelEscolhas.SetActive(false);
        esperandoEscolha = false;

        StartCoroutine(MostrarFalasAlternadas(falasPosMalNPC, falasPosMalJogador));
    }



    IEnumerator MostrarFalasAlternadas(string[] falasNPC, string[] falasJogador)
    {
        int total = Mathf.Min(falasNPC.Length, falasJogador.Length);

        for (int i = 0; i < total; i++)
        {
            textoNPC.text = falasNPC[i];
            textoJogador.text = "";
            yield return new WaitForSecondsRealtime(2f);

            textoNPC.text = "";
            textoJogador.text = falasJogador[i];
            yield return new WaitForSecondsRealtime(2f);
        }

        
    }

    
}
