using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
   [Header("Interação")]
    public GameObject AperteE;

    [Header("Diálogo")]
    public string[] LinhasDeDialogo;
    public string npcName = "NPC 1";

    [Header("Quest")]
    public string questName = "QuestNPC1";
    [TextArea] public string questDescription = "Descrição da primeira quest.";
    public int painelID = 1;

    private bool PlayerAlcance = false;

    void Start()
    {
        if (AperteE != null)
            AperteE.SetActive(false);
    }

    void Update()
    {
        if (PlayerAlcance && Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager.instance.StartDialogue(
                LinhasDeDialogo,
                npcName,
                questName,
                painelID,
                questDescription
            );

            if (AperteE != null)
                AperteE.SetActive(false);
        }
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