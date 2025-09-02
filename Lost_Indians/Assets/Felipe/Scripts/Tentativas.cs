using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tentativas : MonoBehaviour
{
    public int tentativasMaximas = 3;
    public static int tentativasRestantes; // ?? Global
    public TextMeshProUGUI textoTentativas;
    public Button botaoTentativas;

    void Start()
    {
        if (tentativasRestantes == 0)
            tentativasRestantes = tentativasMaximas;

        AtualizarTextoTentativas();

        // ?? Só adiciona se tiver botão
        if (botaoTentativas != null)
            botaoTentativas.onClick.AddListener(DiminuirTentativas);
    }

    public void DiminuirTentativas()
    {
        tentativasRestantes--;
        AtualizarTextoTentativas();

        if (tentativasRestantes <= 0)
        {
            textoTentativas.text = "Sem tentativas restantes!";
            ResetarTentativas();
        }
    }

    void AtualizarTextoTentativas()
    {
        if (textoTentativas != null)
            textoTentativas.text = "Tentativas: " + tentativasRestantes;
    }

    public void ResetarTentativas()
    {
        tentativasRestantes = tentativasMaximas;
        AtualizarTextoTentativas();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}