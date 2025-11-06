using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SairDoJogo : MonoBehaviour
{[Header("Bot�es")]
    public Button playButton;
    public Button quitButton;
    public GameObject creditosPanel;

    [Header("Configura��es")]
    public string sceneToLoad = "GameScene";

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(PlayGame);
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneToLoad);

        Debug.Log("Carregando cena: " + sceneToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Se estiver em build compilado
        Application.Quit();
#endif
    }

    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    public void AbrirCreditos()
    {
        if (creditosPanel != null)
            creditosPanel.SetActive(true);
    }

    // Fecha o painel
    public void FecharCreditos()
    {
        if (creditosPanel != null)
            creditosPanel.SetActive(false);
    }
}