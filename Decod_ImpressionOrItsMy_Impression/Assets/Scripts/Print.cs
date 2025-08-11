using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Print : MonoBehaviour
{
    [SerializeField]
    TMP_InputField Papel;
    [SerializeField] public Button Botão;      

    public int n;
    void Start()
    {
        Impressão_ou_é_Impressão_Minha(n);        
    }
    void Impressão_ou_é_Impressão_Minha(int n)
    {
        for (int i = 0; i < n; i++)
        {
            string resultado = "";
            for (int j = 0; j < i + 1; j++)
            {
                resultado += j + 1 + " ";          // i+1      
            }
            Debug.Log(resultado);

        }
    }

}