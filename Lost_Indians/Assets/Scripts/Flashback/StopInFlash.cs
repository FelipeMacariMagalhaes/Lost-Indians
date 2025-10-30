using UnityEngine;

public class StopInFlash : MonoBehaviour
{
    public MoveTopDown moviTopDown;
    public Movi_2 movi_Plataform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moviTopDown.enabled = false;
            movi_Plataform.enabled = false;
        }
    }
}
