using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    [Header("UI")]
    public GameObject questPanel;
    public TextMeshProUGUI questTitleText;
    public TextMeshProUGUI questDescriptionText;

    private bool questUnlocked = false; 
    private bool questActive = false;   

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        questPanel.SetActive(false);
    }

    public void StartQuest(string questName)
    {
        questUnlocked = true;
        questActive = true;

        questPanel.SetActive(true);
        questTitleText.text = questName;
        questDescriptionText.text = "AAA";
    }

    public bool IsQuestActive()
    {
        return questActive;
    }

    public void CompleteQuest()
    {
        questActive = false;
        questPanel.SetActive(false);
    }

    void Update()
    {
        if (questUnlocked && Input.GetKeyDown(KeyCode.Q))
        {
            questPanel.SetActive(!questPanel.activeSelf);
        }
    }
}
