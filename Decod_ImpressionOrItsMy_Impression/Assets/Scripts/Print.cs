using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Print : MonoBehaviour
{
    [SerializeField]
    TMP_InputField Papel;
    [SerializeField] public Button Bot�o;   
    void Start()
    {
        Bot�o.onClick.AddListener(() => Impress�o_ou_�_Impress�o_Minha());
    }

    void Impress�o_ou_�_Impress�o_Minha()
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
