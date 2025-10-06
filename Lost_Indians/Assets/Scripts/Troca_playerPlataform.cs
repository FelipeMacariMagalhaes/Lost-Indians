using UnityEngine;

public class Troca_playerPlataform : MonoBehaviour
{
    public GameObject PlataformObject;
    public bool plataform = false;
    public Troca_player_TopDown player_TopDown;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Player") && plataform == false)
        {
            player_TopDown.topDown = false;
            plataform = true;           
            player_TopDown.Update_Player();
        }
    }
   
}
