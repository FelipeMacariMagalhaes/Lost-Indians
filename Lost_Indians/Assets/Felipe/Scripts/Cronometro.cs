using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class Cronometro : MonoBehaviour
{
    public float tempoRestante = 60f;
    public float tempoEsgotado = 0f;
    [SerializeField] private TextMeshProUGUI textoCronometro; 
    private bool cronometroAtivo = false;

    void Start()
    {

        IniciarCronometro();
        //Este inicia o cronomtro automaticamente
    }

    void Update()
    {
        
        if (cronometroAtivo)
        {
            if (tempoRestante > 0)
            {
                tempoRestante -= Time.deltaTime;
                textoCronometro.text = "Voce Conseguiu";
                AtualizarTextoCronometro();
            }
            else
            {
                tempoRestante = 0;
                cronometroAtivo = false;
                textoCronometro.text = "Tempo esgotado!";
            }
        }
    }

    void AtualizarTextoCronometro()
    {
        int minutos = Mathf.FloorToInt(tempoRestante / 60);
        int segundos = Mathf.FloorToInt(tempoRestante % 60);
        textoCronometro.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void IniciarCronometro()
    {
        cronometroAtivo = true;
    }

    public void PausarCronometro()
    {
        cronometroAtivo = false;
    }

    public void ReiniciarCronometro()
    {
        tempoRestante = 60f;
        cronometroAtivo = true;
       
        AtualizarTextoCronometro();
    }
}

