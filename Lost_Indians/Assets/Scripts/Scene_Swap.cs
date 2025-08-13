using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Swap : MonoBehaviour
{
    public string sceneName;
   private void OnMouseDown ()
    {        
        SceneManager.LoadScene(sceneName);
    }
}
