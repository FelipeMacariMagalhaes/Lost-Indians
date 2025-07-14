using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Print : MonoBehaviour
{
    [SerializeField]
    TMP_InputField Papel;
    [SerializeField] public Button Botão;   
    void Start()
    {
        Botão.onClick.AddListener(() => Impressão_ou_é_Impressão_Minha());
    }

    void Impressão_ou_é_Impressão_Minha()
    {
        string escrita = Papel.text.Trim();
        escrita = escrita.Replace(".", "").Replace("-", "");
        int n = escrita.Length;
        for (int i = 0; i <= 9; i++)
        {
            Debug.Log($"{n}, {n}");
        }
       
        
    }
    
}
