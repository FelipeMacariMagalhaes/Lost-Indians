using UnityEngine;

public class Troca_playerPlataform : MonoBehaviour
{   
    public bool plataform = false;
    public Troca_player_TopDown player_TopDown;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Player") && !plataform)
        {
            player_TopDown.topDown = false;
            plataform = true;           
            player_TopDown.Update_Player();
        }
    }
   
}
