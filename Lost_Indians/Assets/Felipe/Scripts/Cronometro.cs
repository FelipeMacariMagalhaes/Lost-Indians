using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Numerics;


public class Cronometro : MonoBehaviour
{
    [SerializeField] public Button btn;

    public TextMeshProUGUI textoCronometro;
    
    public GameObject painelVitoria;

    public GameObject painelDerrota;
    public Jogodaforca2000 Jogodaforca2000;
    public GameObject cronometragem;

    public float tempoRestante = 10f;

    private bool terminou = false;

    private bool venceu = false;

    void Start()

    {
        Jogodaforca2000 = FindObjectOfType<Jogodaforca2000>();

        painelVitoria.SetActive(false);

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

            if (venceu)

            {

                MostrarVitoria();

            }

            else

            {

                MostrarDerrota();

            }

        }

    }

    public void VencerJogo()

    {

        if (terminou)

        {

            venceu = true;

            terminou = true;

            MostrarVitoria();

        }

    }

    public void MostrarVitoria()

    {

        painelVitoria.SetActive(true);
        cronometragem.SetActive(false);
        Debug.Log(" Vitória! Palavra secreta: " + Jogodaforca2000.palavraSecreta);

        Time.timeScale = 0f;
       
        
           
        
        

        

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

        Time.timeScale = 1f; // jogo volta

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
 


