using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public GameObject questPanel;
    public TextMeshProUGUI questTitleText;
    public TextMeshProUGUI questDescriptionText;

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
        questActive = true;
        questPanel.SetActive(true);

        questTitleText.text = questName;
        questDescriptionText.text = "Você viu aquilo?";
    }

    public bool IsQuestActive()
    {
        return questActive;
    }

    public void CompleteQuest()
    {
        questActive = false;
        questPanel.SetActive(false);

        questDescriptionText.text = "O que sera que era?";
    }
}
