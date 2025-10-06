using UnityEngine;

public class Player_form_detection : MonoBehaviour
{
    public Troca_player_TopDown player_TopDown;
    public Troca_playerPlataform player_Plataform;
    public MoveTopDown moviTopDown;
    public Movi_2 movi_Plataform;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (player_Plataform.plataform == true) 
        {
            movi_Plataform.enabled = true;
            moviTopDown.enabled = false;
        }
        if (player_TopDown.topDown == true) 
        {
            movi_Plataform.enabled = false;
            moviTopDown.enabled = true;
        }

    }
}
