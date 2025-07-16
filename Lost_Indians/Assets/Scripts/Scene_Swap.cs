using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Swap : MonoBehaviour
{
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
