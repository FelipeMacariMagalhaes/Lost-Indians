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
    public Button BotaoQuest;

    [Header("Typing Settings")]
    public float SegPorLetra = 0.03f;

    private string[] lines;
    private int index;
    private bool EstaEscrevendo;
    private bool ignorarInputInicial = false;   

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

        if (BotaoQuest != null)
        {
            BotaoQuest.gameObject.SetActive(false);
            BotaoQuest.onClick.AddListener(AceitarQuest);
        }
    }

    public void StartDialogue(string[] dialogueLines, string npcName = "")
    {
        lines = dialogueLines;
        index = 0;
        dialoguePanel.SetActive(true);

        if (nameText != null)
            nameText.text = npcName;

        if (BotaoQuest != null)
            BotaoQuest.gameObject.SetActive(false);

        ignorarInputInicial = true;   
        StartCoroutine(LiberarInput());

        StartCoroutine(TypeLine());
    }

    IEnumerator LiberarInput()
    {
        yield return null;             
        ignorarInputInicial = false;   
    }

    void Update()
    {
        if (ignorarInputInicial) return;  

        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            if (EstaEscrevendo)
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
                EstaEscrevendo = false;
            }
            else
            {
                ProximaLinha();
            }
        }
    }

    IEnumerator TypeLine()
    {
        EstaEscrevendo = true;
        dialogueText.text = "";

        foreach (char c in lines[index])
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(SegPorLetra);
        }

        EstaEscrevendo = false;
    }

    void ProximaLinha()
    {
        index++;

        if (index < lines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            if (BotaoQuest != null)
                BotaoQuest.gameObject.SetActive(true);
        }
    }

    void AceitarQuest()
    {
        QuestManager.instance.StartQuest("Missão do NPC");

        dialoguePanel.SetActive(false);
        BotaoQuest.gameObject.SetActive(false);
    }
}
