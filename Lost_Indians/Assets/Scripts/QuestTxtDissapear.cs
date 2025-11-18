using UnityEngine;
using UnityEngine.Events;
public class QuestTxtDissapear : MonoBehaviour
{
    public Game_Controller game_Controller;
    public UnityEvent Desactive;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (game_Controller.foundObjects == 5)
        {
            Desactive.Invoke();
        }
    }
}
