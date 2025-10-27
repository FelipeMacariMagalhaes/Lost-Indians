using UnityEngine;
using UnityEngine.Events;

public class Top_down_active : MonoBehaviour
{
    public bool Topdown_active = true;
    public Caven_active cavern_Active;
    public UnityEvent TopDown;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Topdown_active = true;
            cavern_Active.Cavern_active = false;
            TopDown.Invoke();
        }
    }
}
