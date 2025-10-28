using UnityEngine;
using UnityEngine.Events;
public class Exit_flashback : MonoBehaviour
{
    public UnityEvent exit_flash;
    public GameObject Player;
    public Transform Teleport_flashOut;
    public Movi_2 movi_Plataform;
    public MoveTopDown moviTopDown;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            exit_flash.Invoke();
            Player.transform.position = Teleport_flashOut.transform.position;
            movi_Plataform.enabled = true;
            moviTopDown.enabled = true;
        }
    }
}
