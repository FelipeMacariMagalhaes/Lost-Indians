using UnityEngine;

public class QuestItem3 : MonoBehaviour
{
    public string questName = "QuestNPC3";  

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (QuestManager.instance.IsQuestActive(questName))
            {
                QuestManager.instance.CompleteQuest();
                Destroy(gameObject);
            }
        }
    }
}