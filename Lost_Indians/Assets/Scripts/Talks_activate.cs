using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
public class Talks_activate : MonoBehaviour
{
    public UnityEvent talk;
    public GameObject player;
    public Transform TeleporteFlash;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            talk.Invoke();            
            player.transform.position = TeleporteFlash.position;               
            
        }
    }
}
