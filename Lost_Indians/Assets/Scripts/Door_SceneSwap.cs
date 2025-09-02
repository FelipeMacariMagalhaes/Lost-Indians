using UnityEngine;
using UnityEngine.SceneManagement;
public class Door_SceneSwap : MonoBehaviour
{
    public string sceneName;    
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }

    }
    
}
