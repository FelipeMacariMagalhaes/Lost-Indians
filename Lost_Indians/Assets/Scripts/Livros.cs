using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Livros : MonoBehaviour
{
    public PlayableDirector cutscene;
    private void OnMouseDown()
    {
        if(cutscene != null)
        {
            cutscene.Play();
        }
    }
}
