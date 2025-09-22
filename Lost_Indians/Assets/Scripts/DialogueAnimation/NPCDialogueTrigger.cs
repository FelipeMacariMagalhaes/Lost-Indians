using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] dialogueLines;
    public string npcName = "NPC";
    public Sprite npcPortrait;

    [Header("UI de Interacao")]
    public GameObject uINpc;
    private bool playerInRange;

    void Start()
    {
        if(uINpc != null)
        {
            uINpc.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager.instance.StartDialogue(dialogueLines, npcName, npcPortrait);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if(uINpc !=null)
               uINpc.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if(uINpc !=null)
               uINpc.SetActive(false);
        }
    }
}
