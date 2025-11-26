using UnityEngine;

public class NPCDialogueTrigger2 : MonoBehaviour
{
    [Header("Interação")]
    public GameObject AperteE;

    [Header("Diálogo")]
    public string[] LinhasDeDialogo;
    public string npcName = "NPC 3";

    [Header("Quest")]
    public string questName = "QuestNPC3";
    [TextArea] public string questDescription = "Descrição da terceira quest.";
    public int painelID = 3;

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
