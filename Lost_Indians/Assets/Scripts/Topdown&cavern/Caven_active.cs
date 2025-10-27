using UnityEngine;
using UnityEngine.Events;
public class Caven_active : MonoBehaviour
{
    public bool Cavern_active = false;
    public Top_down_active top_Active;
    public UnityEvent Cavern;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Cavern_active = true;
            top_Active.Topdown_active = false;
            Cavern.Invoke();
        }
    }
}
