using UnityEngine;
using UnityEngine.SceneManagement;
public class Door_SceneSwap : MonoBehaviour
{ 
    public string SceneName;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneName);
            Debug.Log("Colidiu");
        }

    }
    
}
