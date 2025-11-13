using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;



public class Cronometro : MonoBehaviour
{
    [SerializeField] public Button btn;

    public TextMeshProUGUI textoCronometro;
    public GameObject painelDerrota;
    
    public GameObject cronometragem;

    public float tempoRestante = 10f;

    private bool terminou = false;

    private bool venceu = false;

    void Start()

    {  

        

        painelDerrota.SetActive(false);

        cronometragem.SetActive(true);

        Time.timeScale = 1f; // o jogo volta ao normal ao reiniciar

    }

    void Update()

    {
           

        if (terminou) return;

        tempoRestante -= Time.deltaTime;

        if (tempoRestante > 0)

        {

            int segundos = Mathf.FloorToInt(tempoRestante);

            textoCronometro.text = segundos.ToString();
            

        }

        else

        {

            tempoRestante = 0;

            textoCronometro.text = "Tempo esgotado!";

            terminou = true;
            painelDerrota.SetActive (true);
            cronometragem.SetActive (false);

       
           
                MostrarDerrota();

           

        }

    }

   
    

    public void MostrarDerrota()

    {
        painelDerrota.SetActive(true);
        cronometragem.SetActive(false);

        textoCronometro.color = Color.red;

        Time.timeScale = 0f;
    }

    // chamado pelo botao famoso Tentar de novo

    public void TentarDeNovo()
    {

        Time.timeScale = 3f; // jogo volta
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

}


 


