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

    [Header("Painéis de Quest")]
    public GameObject questPainel1;
    public GameObject questPainel2;
    public GameObject questPainel3;

    public TextMeshProUGUI questTitle1;
    public TextMeshProUGUI questTitle2;
    public TextMeshProUGUI questTitle3;

    public TextMeshProUGUI questDesc1;
    public TextMeshProUGUI questDesc2;
    public TextMeshProUGUI questDesc3;

    [Header("Typing")]
    public float segPorLetra = 0.03f;

    private string[] falas;
    private int index = 0;

    private bool escrevendo = false;
    private bool terminouDialogo = false;

    private string questNameAtual = "";
    private string descAtual = "";
    private int painelIDAtual = 1;

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

        // Garantir que o botão sempre chama AceitarQuest
        botaoQuest.onClick.RemoveAllListeners();
        botaoQuest.onClick.AddListener(AceitarQuest);
    }

    public void StartDialogue(string[] linhas, string nomeNPC, string questName, int painelID, string descQuest)
    {
        StopAllCoroutines(); // Para qualquer digitação antiga

        falas = linhas;
        index = 0;
        terminouDialogo = false;
        escrevendo = false;

        if (!dialoguePanel.activeSelf)
            dialoguePanel.SetActive(true);

        botaoQuest.gameObject.SetActive(false);

        nameText.text = nomeNPC;
        dialogueText.text = "";

        questNameAtual = questName;
        painelIDAtual = painelID;
        descAtual = descQuest;

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
        botaoQuest.gameObject.SetActive(false);
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
        QuestManager.instance.StartQuest(questNameAtual);

        dialoguePanel.SetActive(false);
        botaoQuest.gameObject.SetActive(false);

        if (painelIDAtual == 1)
        {
            questPainel1.SetActive(true);
            questTitle1.text = questNameAtual;
            questDesc1.text = descAtual;
        }
        else if (painelIDAtual == 2)
        {
            questPainel2.SetActive(true);
            questTitle2.text = questNameAtual;
            questDesc2.text = descAtual;
        }
        else if (painelIDAtual == 3)
        {
            questPainel3.SetActive(true);
            questTitle3.text = questNameAtual;
            questDesc3.text = descAtual;
        }
    }
}
