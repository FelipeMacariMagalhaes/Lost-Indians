using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Argumento : MonoBehaviour
{
    [SerializeField]
    TMP_InputField Papel;
    [SerializeField] public Button Botão;
    [SerializeField]
    TMP_Text Results;

    public int x; 
    public int y;
    public int z;
    public int w;
    public int P;
    public int N;
    void Start()
    {
        Somar();
       string aveneia = Carater_D_A_People(w);
    }

    void Somar()
    {
        Debug.Log($"Soma dos três argumentos: {x + (y) + (z)}");
    }

    string Carater_D_A_People (Text w)
    {
        string cpf = w.text.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        int total = 0;
        if (w > 0)
        {
          return Debug.Log(P);          
        }

        else if (w <= 0)
        {
            Debug.Log(N);
        }

    }

}
