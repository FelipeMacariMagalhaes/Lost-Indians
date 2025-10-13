using UnityEngine;

using UnityEngine.Events;
public class Livros : CountBooks
{
    bool flashOn = false;
    public UnityEvent Flashbacks;
    public UnityEvent NonFlashBacks;
    
    private void Start()
    {
        CollectMessage = "Você Coletou Um livro";
        if (flashOn == false)
        {
            NonFlashBacks.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Flashbacks.Invoke();
        flashOn = true;      
    }
}
    





