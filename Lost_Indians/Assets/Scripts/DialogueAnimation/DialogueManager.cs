using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;

    [Header("Typing Settings")]
    public float typingSpeed = 0.03f;

    private string[] lines;
    private int index;
    private bool isTyping;

    public static DialogueManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(string[] dialogueLines, string npcName = "")
    {
        lines = dialogueLines;
        index = 0;
        dialoguePanel.SetActive(true);

        if (nameText != null)
            nameText.text = npcName;

        StartCoroutine(TypeLine());
    }

    void Update()
    {
        // Avança diálogo com E
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in lines[index])
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void NextLine()
    {
        index++;

        if (index < lines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
