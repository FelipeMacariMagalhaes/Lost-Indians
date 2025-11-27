using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    public string sceneName;
    public void Menu()
    {
        SceneManager.LoadScene(sceneName);
    }
}
