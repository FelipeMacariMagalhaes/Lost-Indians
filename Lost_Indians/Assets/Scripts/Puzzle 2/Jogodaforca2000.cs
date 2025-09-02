using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Jogodaforca2000 : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textoForca;
    [SerializeField] private TextMeshProUGUI AVISO;
    [SerializeField] private TMP_InputField letra;
    [SerializeField] private Button verificarButton;
    [SerializeField] public string palavraSecreta = "MAIRA";
    

    void Start()
    {
        AVISO.text = "";
        textoForca.text = "";
        foreach (char letra in palavraSecreta)
        {
            textoForca.text += "_";
        }
        verificarButton.onClick.AddListener(VerificarLetra);
    }


    public void VerificarLetra()
    {
        string letraDigitada = letra.text.ToLower();
        if (letraDigitada.Length != 1)
        {
            AVISO.text = "Por favor, digite apenas uma letra.";
            AVISO.color = Color.red;
            return;
        }

        if (palavraSecreta.Contains(letraDigitada))
        {
            AVISO.text = "A letra '" + letraDigitada + "' está na palavra!";
            AVISO.color = Color.green;
            for (int i = 0; i < palavraSecreta.Length; i++)
            {
                if (palavraSecreta[i].ToString() == letraDigitada)
                {
                    char[] textoAtual = textoForca.text.ToCharArray();
                    textoAtual[i] = letraDigitada[0];
                    textoForca.text = new string(textoAtual);
                }
            }
        }
        else
        {
            AVISO.text = "A letra '" + letraDigitada + "' não está na palavra.";
            AVISO.color = Color.red;
        }
        letra.text = "";

    }
    
}





