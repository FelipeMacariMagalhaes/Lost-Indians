using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Livros : CountBooks
{
    private void Start()
    {
        CollectMessage = "Você Coletou Um livro";
    }
}
    public class Livros2 : CountBooks

{
    private void Start()
    {
        CollectMessage = "Você Coletou o Segundo livro";

    }
}
    public class Livros3 : CountBooks
{
        private void Start()
        {
            CollectMessage = "Voce Coletou o Terceiro Livro";

        }




}
