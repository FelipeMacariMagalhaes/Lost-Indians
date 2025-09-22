using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    [Header("Interação")]
    public GameObject pressEUI; 

    [Header("Diálogo")]
    public string[] dialogueLines;
    public string npcName = "NPC";

    private bool playerInRange = false;

    void Start()
    {
        if (pressEUI != null)
            pressEUI.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager.instance.StartDialogue(dialogueLines, npcName);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (pressEUI != null)
                pressEUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (pressEUI != null)
                pressEUI.SetActive(false);
        }
    }
}
