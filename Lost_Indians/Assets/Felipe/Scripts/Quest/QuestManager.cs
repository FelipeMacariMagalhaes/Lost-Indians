using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    private string activeQuest = "";

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void StartQuest(string questName)
    {
        activeQuest = questName;
        Debug.Log("Quest iniciada: " + activeQuest);
    }

    public bool IsQuestActive(string questName)
    {
        return activeQuest == questName;
    }

    public void CompleteQuest()
    {
        Debug.Log("Quest completa: " + activeQuest);
        activeQuest = "";
    }
}
