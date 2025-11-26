using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    [Header("Interação")]
    public GameObject AperteE;

    [Header("Diálogo")]
    public string[] LinhasDeDialogoFase1;  // Diálogo para a fase 1 (Aceitar quest 1)
    public string[] LinhasDeDialogoFase2;  // Diálogo para a fase 2 (Aceitar quest 2)
    public string[] LinhasDeDialogoFase3;  // Diálogo para a fase 3 (Aceitar quest 3)
    public string npcName = "NPC 1";

    [Header("Quest")]
    public string questName1 = "Quest 1";
    public string questDescription1 = "Descrição da Quest 1.";

    public string questName2 = "Quest 2";
    public string questDescription2 = "Descrição da Quest 2.";

    public string questName3 = "Quest 3";
    public string questDescription3 = "Descrição da Quest 3.";

    private bool PlayerAlcance = false;
    public int questStage = 0;  // Fase da quest (0 = nenhuma quest aceita, 1 = quest 1, 2 = quest 2, 3 = quest 3)

    void Start()
    {
        if (AperteE != null)
            AperteE.SetActive(false);
    }

    void Update()
    {
        if (PlayerAlcance && Input.GetKeyDown(KeyCode.E))
        {
            // Inicia o diálogo com base na fase da quest
            if (questStage == 0)  // Se a quest ainda não foi aceita
            {
                DialogueManager.instance.StartDialogue(
                    LinhasDeDialogoFase1,
                    npcName,
                    questName1,
                    questDescription1
                );
                questStage = 1;  // Passa para a fase 1 após o diálogo inicial
            }
            else if (questStage == 1)  // Se a quest 1 foi aceita
            {
                DialogueManager.instance.StartDialogue(
                    LinhasDeDialogoFase2,
                    npcName,
                    questName2,
                    questDescription2
                );
                questStage = 2;  // Passa para a fase 2
            }
            else if (questStage == 2)  // Se a quest 2 foi aceita
            {
                DialogueManager.instance.StartDialogue(
                    LinhasDeDialogoFase3,
                    npcName,
                    questName3,
                    questDescription3
                );
                questStage = 3;  // Passa para a fase 3 ou completa a missão
            }

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
