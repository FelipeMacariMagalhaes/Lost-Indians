using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class SairDoJogo : MonoBehaviour
{
    [Header("Bot�es")]
    public Button playButton;
    public Button quitButton;
    public Button closeButton;

    public GameObject creditosPanel;
    public UnityEvent Credits;
    public UnityEvent close;
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
        Credits.Invoke();
    }   

    public void CloseCreditos()
    {
        close.Invoke();
    }
}