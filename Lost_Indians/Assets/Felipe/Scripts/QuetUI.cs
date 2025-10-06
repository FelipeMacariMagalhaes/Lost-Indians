using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public static QuestUI instance;

    public GameObject questPanel;
    public TextMeshProUGUI questText;

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

    public void ShowQuest(string questName)
    {
        questPanel.SetActive(true);
        questText.text = "Missão: " + questName;
    }

    public void HideQuest()
    {
        questPanel.SetActive(false);
    }

    public void UpdateQuestText(string newText)
    {
        questText.text = newText;
    }
}
