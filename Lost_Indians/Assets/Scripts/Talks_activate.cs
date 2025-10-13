using UnityEngine;
using UnityEngine.Events;
public class Talks_activate : MonoBehaviour
{
    public UnityEvent talk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            talk.Invoke();
        }
    }
}
