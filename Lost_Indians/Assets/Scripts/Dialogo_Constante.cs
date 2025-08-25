using TMPro;
using UnityEngine;
using System.Collections;

public class Dialogo_Constante : MonoBehaviour
{public GameObject painelDialogo;

public TextMeshProUGUI textoJogador;

float Delay_s = 2f;

public string[] falasJogador;

private int indiceFala = 0;
public bool dialogoAtivo = false;
private bool esperandoEscolha = false;

void Start()
{
    painelDialogo.SetActive(false);    
    dialogoAtivo = false;
    IniciarDialogo();
}

void Update()
{
    if (dialogoAtivo && Input.GetKeyDown(KeyCode.D))
    {
       AvancarFala();
    }
}

public void IniciarDialogo()
{       
    if (falasJogador.Length == 0) return;

    indiceFala = 0;
    painelDialogo.SetActive(true);
    AtualizarFalas();
    dialogoAtivo = true;


}

public void AvancarFala()
{
    indiceFala++;

    if (indiceFala < falasJogador.Length)
    {
        AtualizarFalas();

        if (indiceFala == falasJogador.Length - 1)
        {          
            Invoke(nameof(painelDialogo), Delay_s);
        }
    }    
}

void AtualizarFalas()
{
    textoJogador.text = falasJogador[indiceFala];
}



IEnumerator MostrarFalasAlternadas(string[] falasJogador)
{
    int total = Mathf.Min(falasJogador.Length, falasJogador.Length);

    for (int i = 0; i < total; i++)
    {
        textoJogador.text = "";
        textoJogador.text = falasJogador[i];
        yield return new WaitForSecondsRealtime(Delay_s);
    }


}

    
}
