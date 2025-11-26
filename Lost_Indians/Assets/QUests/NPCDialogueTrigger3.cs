using UnityEngine;

public class NPCDialogueTrigger3 : MonoBehaviour
{
     [Header("Interação")]
    public GameObject AperteE;

    [Header("Diálogo")]
    public string[] LinhasDeDialogo;
    public string npcName = "NPC";

    [Header("Quest")]
    public string questName = "";
    [TextArea] public string questDescription = "";
    public int painelID = 1;  

    private bool PlayerAlcance = false;

    void Start()
    {
        if (AperteE != null)
            AperteE.SetActive(false);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAlcance = true;
            if (AperteE != null) AperteE.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAlcance = false;
            if (AperteE != null) AperteE.SetActive(false);
        }
    }
}
