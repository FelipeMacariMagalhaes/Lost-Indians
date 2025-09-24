using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
   [Header("Interação")]
    public GameObject pressEUI;   
    public Vector3 offset = new Vector3(0, 1f, 0); 
 
    [Header("Diálogo")]
    public string[] dialogueLines;
    public string npcName = "NPC";
 
    private bool playerInRange = false;
    private Camera cam;
 
    void Start()
    {
        cam = Camera.main;
 
        if (pressEUI != null)
            pressEUI.SetActive(false);
    }
 
    void Update()
    {
        if (playerInRange)
        {
            // Atualiza a posição do texto na tela (fixo acima da cabeça)
            if (pressEUI != null)
            {
                Vector3 screenPos = cam.WorldToScreenPoint(transform.position + offset);
                pressEUI.transform.position = screenPos;
            }
 
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.instance.StartDialogue(dialogueLines, npcName);
            }
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