using UnityEngine;
using System;
using UnityEngine.Events;
public class Livros : CountBooks
{
    public Transform Player;
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
        if (other.CompareTag("Player"))
        {
            Flashbacks.Invoke();
            flashOn = true;
            transform.localScale = new Vector2(13, 5);
        }       
    }
}
    





