using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    private bool questActive = false;
    private bool questCompleted = false;
    private string currentQuest;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void StartQuest(string questName)
    {
        currentQuest = questName;
        questActive = true;
        questCompleted = false;
        QuestUI.instance.ShowQuest(questName);
    }

    public void CompleteQuest()
    {
        if (questActive)
        {
            questActive = false;
            questCompleted = true;
            QuestUI.instance.HideQuest();
        }
    }

    public bool IsQuestActive()
    {
        return questActive;
    }

    public bool IsQuestCompleted()
    {
        return questCompleted;
    }

    public string GetCurrentQuest()
    {
        return currentQuest;
    }
}
