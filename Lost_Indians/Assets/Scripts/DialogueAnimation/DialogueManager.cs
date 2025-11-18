using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Button botaoQuest;

    [Header("Typing")]
    public float segPorLetra = 0.03f;

    private string[] falas;
    private int index = 0;

    private bool escrevendo = false;
    private bool terminouDialogo = false;

    public static DialogueManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        dialoguePanel.SetActive(false);
        botaoQuest.gameObject.SetActive(false);
        botaoQuest.onClick.AddListener(AceitarQuest);
    }

    public void StartDialogue(string[] linhas, string nomeNPC = "")
    {
        falas = linhas;
        index = 0;
        terminouDialogo = false;

        dialoguePanel.SetActive(true);
        botaoQuest.gameObject.SetActive(false);

        nameText.text = nomeNPC;
        dialogueText.text = "";

        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (!dialoguePanel.activeSelf) return;
        if (terminouDialogo) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (escrevendo)
            {
                StopAllCoroutines();
                dialogueText.text = falas[index];
                escrevendo = false;
                return;
            }

            // Senão, ir para próxima linha
            ProximaLinha();
        }
    }

    IEnumerator TypeLine()
    {
        escrevendo = true;
        dialogueText.text = "";

        foreach (char c in falas[index])
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(segPorLetra);
        }

        escrevendo = false;
    }

    void ProximaLinha()
    {
        index++;

        if (index < falas.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            FimDoDialogo();
        }
    }

    void FimDoDialogo()
    {
        terminouDialogo = true;
        botaoQuest.gameObject.SetActive(true);
    }

    void AceitarQuest()
    {
        QuestManager.instance.StartQuest("Missão do NPC");

        dialoguePanel.SetActive(false);
        botaoQuest.gameObject.SetActive(false);
    }
}
