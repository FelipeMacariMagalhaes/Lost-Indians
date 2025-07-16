using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Jogodaforca2000 : MonoBehaviour
{
    public TMP_Text textoPalavra;
    public TMP_InputField entradaLetra;
    public TMP_Text textoVidas;

    string palavra = "cabeça";
    char[] exibicao;
    int vidas = 3;

    void Start()
    {
        exibicao = new string('*', palavra.Length).ToCharArray();
        AtualizarTexto();
        AtualizarVidas();
    }

    public void VerificarLetra()
    {
        string entrada = entradaLetra.text.ToLower();

        if (entrada.Length == 1)
        {
            char letra = entrada[0];
            bool acertou = false;

            for (int i = 0; i < palavra.Length; i++)
            {
                if (palavra[i] == letra)
                {
                    exibicao[i] = letra;
                    acertou = true;
                }
            }

            if (!acertou)
            {
                vidas--;
                AtualizarVidas();
                if (vidas <= 0) SceneManager.LoadScene("Title");
            }

            AtualizarTexto();
            if (new string(exibicao) == palavra) SceneManager.LoadScene("Vitoria");
        }

        entradaLetra.text = "";
        entradaLetra.ActivateInputField();
    }

    void AtualizarTexto() => textoPalavra.text = string.Join(" ", exibicao);
    void AtualizarVidas() => textoVidas.text = "Vidas: " + vidas;
}




