using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Livros : CountBooks
{
    public PlayableDirector cutsceneDirector;
    private void Start()
    {
        CollectMessage = "Você Coletou Um livro";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cutsceneDirector.Play();
        }
    }
}
    





