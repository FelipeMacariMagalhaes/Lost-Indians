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

    [Header("Painel da Quest")]
    public GameObject questPainel;
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDesc;

    [Header("Typing")]
    public float segPorLetra = 0.03f;

    private string[] falas;
    private int index = 0;

    private bool escrevendo = false;
    private bool terminouDialogo = false;

    private string questNameAtual = "";
    private string descAtual = "";

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

    // Inicia o diálogo e passa as falas
    public void StartDialogue(string[] linhas, string nomeNPC, string questName, string descQuest)
    {
        StopAllCoroutines(); // Para qualquer digitação antiga

        falas = linhas;
        index = 0;
        terminouDialogo = false;
        escrevendo = false;

        if (!dialoguePanel.activeSelf)
            dialoguePanel.SetActive(true);

        botaoQuest.gameObject.SetActive(false);  // Esconde o botão inicialmente

        nameText.text = nomeNPC;
        dialogueText.text = "";

        questNameAtual = questName;
        descAtual = descQuest;

        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (!dialoguePanel.activeSelf) return;
        if (terminouDialogo) return;

        // O jogador avança o diálogo ao pressionar o espaço
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

    // Efeito de digitação
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

    // Avança para a próxima linha do diálogo
    void ProximaLinha()
    {
        botaoQuest.gameObject.SetActive(false);  // Esconde o botão enquanto o diálogo continua
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

    // Finaliza o diálogo e mostra o botão de aceitar a quest
    void FimDoDialogo()
    {
        terminouDialogo = true;
        botaoQuest.gameObject.SetActive(true);  // Mostra o botão de quest ao final do diálogo
    }

    // Aceitar a quest ao clicar no botão
    void AceitarQuest()
    {
        QuestManager.instance.StartQuest(questNameAtual);

        // Fecha o painel de diálogo e o botão de quest
        dialoguePanel.SetActive(false);
        botaoQuest.gameObject.SetActive(false);

        // Atualiza o painel de quest
        questPainel.SetActive(true);
        questTitle.text = questNameAtual;
        questDesc.text = descAtual;
    }
}
