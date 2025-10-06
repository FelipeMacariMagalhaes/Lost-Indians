using UnityEngine;

public class Troca_player_TopDown : MonoBehaviour
{
    public Troca_playerPlataform player_Plataform;
    public GameObject TopDownObject;
    public bool topDown = true;   
    void Start()
    {
        
    }

   
    void Update()
    {
        Update_Player();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag ("Player") && topDown == false)
        {
            player_Plataform.plataform = false;
            topDown = true;            
            Update_Player();           
        }
    }

    public void Update_Player()
    {
        TopDownObject.SetActive(topDown);
        player_Plataform.PlataformObject.SetActive(player_Plataform.plataform);
    }
}
