using UnityEngine;

using UnityEngine.Events;
public class Livros : CountBooks
{
    public UnityEvent Flashbacks;
    
    private void Start()
    {
        CollectMessage = "Você Coletou Um livro";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Flashbacks.Invoke();
    }
}
    





