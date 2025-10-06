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
        questDescriptionText.text = "Colete o item perdido e retorne ao Guardião!";
    }

    public bool IsQuestActive()
    {
        return questActive;
    }
}
