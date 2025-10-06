using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public Button acceptQuestButton;

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

        // Botão sempre desativado até o final do diálogo
        if (acceptQuestButton != null)
            acceptQuestButton.gameObject.SetActive(false);

        // Adiciona listener para o botão
        if (acceptQuestButton != null)
            acceptQuestButton.onClick.AddListener(AcceptQuest);
    }

    public void StartDialogue(string[] dialogueLines, string npcName = "")
    {
        lines = dialogueLines;
        index = 0;
        dialoguePanel.SetActive(true);

        if (nameText != null)
            nameText.text = npcName;

        // Esconde botão no inicio
        if (acceptQuestButton != null)
            acceptQuestButton.gameObject.SetActive(false);

        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
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
            // Chegou na última linha, mostra o botão de aceitar missão
            if (acceptQuestButton != null)
                acceptQuestButton.gameObject.SetActive(true);
        }
    }

    // Botão de aceitar missão
    public void AcceptQuest()
    {
        // Inicia a missão se ainda não estiver ativa
        if (!QuestManager.instance.IsQuestActive())
        {
            QuestManager.instance.StartQuest("Missão do NPC");
            // Fecha o painel de diálogo
            dialoguePanel.SetActive(false);
            // Esconde o botão
            acceptQuestButton.gameObject.SetActive(false);
        }
    }
}
