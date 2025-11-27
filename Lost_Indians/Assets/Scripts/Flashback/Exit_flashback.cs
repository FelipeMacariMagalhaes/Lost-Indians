using UnityEngine;
using UnityEngine.Events;
public class Exit_flashback : MonoBehaviour
{
    public UnityEvent exit_flash;
    public GameObject Player;
    public GameObject NPC;
    public Transform Teleport_flashOut;
    public Transform Teleport_NPC;
    public Movi_2 movi_Plataform;
    public MoveTopDown moviTopDown;
    public bool plataform;
    public bool topdown;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            exit_flash.Invoke();
            Player.transform.position = Teleport_flashOut.transform.position;
            NPC.transform.position = Teleport_NPC.transform.position;
            movi_Plataform.enabled = plataform;
            moviTopDown.enabled = topdown;
        }
    }
}
