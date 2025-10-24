using UnityEngine;

public class Troca_player_TopDown : MonoBehaviour
{
    public MonoBehaviour[] movementScripts;
    public Troca_playerPlataform player_Plataform;  
    public bool topDown = true;
    public MoveTopDown moviTopDown;
    public Movi_2 movi_Plataform;
    void Start()
    {
        
    }

   
    void Update()
    {
        Update_Player();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag ("Player") && !topDown)
        {
            player_Plataform.plataform = false;
            topDown = true;            
            Update_Player();           
        }
    }

    public void Update_Player()
    {
        movi_Plataform.enabled = player_Plataform.plataform;
        moviTopDown.enabled = topDown;
    }
}
