using UnityEngine;
using UnityEngine.Events;
public class Exit_flashback : MonoBehaviour
{
    public UnityEvent exit_flash;
    public Transform Transform_player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            exit_flash.Invoke();

        }
    }
}
