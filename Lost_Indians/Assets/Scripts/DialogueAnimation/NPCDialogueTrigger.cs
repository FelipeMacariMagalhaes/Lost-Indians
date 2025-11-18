using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    [Header("Interação")]
    public GameObject AperteE;   
    public Vector3 ofset = new Vector3(0, 1f, 0); 

    [Header("Diálogo")]
    public string[] LinhasDeDialogo;
    public string npcName = "NPC";

    private bool PlayerAlcance = false;
    private bool jaInteragiu = false;   
    private Camera cm;

    void Start()
    {
        cm = Camera.main;

        if (AperteE != null)
            AperteE.SetActive(false);
    }

    void Update()
    {
        if (PlayerAlcance && !jaInteragiu)
        {
          

            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.instance.StartDialogue(LinhasDeDialogo, npcName);

                jaInteragiu = true;        
                if (AperteE != null)
                    AperteE.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!jaInteragiu && other.CompareTag("Player"))
        {
            PlayerAlcance = true;
            if (AperteE != null)
                AperteE.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAlcance = false;

            if (!jaInteragiu && AperteE != null)
                AperteE.SetActive(false);
        }
    }
}
