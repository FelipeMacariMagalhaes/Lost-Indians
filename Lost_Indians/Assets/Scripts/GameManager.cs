using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int livrosColetados = 0;
    public int totalDeLivros = 3; 
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LivroColetado()
    {
        livrosColetados++;
        UIManager.Instance.AtualizarContador(livrosColetados);

        if (livrosColetados >= totalDeLivros)
        {
        UIManager.Instance.ShowMessage("Você coletou todos os livros!", 3f);
        //aqui depois adicionar alguma troca tipo cena ou aparecer uma timeline ou etc.
        }
    }
}
