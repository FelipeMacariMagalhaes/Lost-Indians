using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public string questName = "Missão do NPC";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (QuestManager.instance.IsQuestActive())
            {
                QuestManager.instance.CompleteQuest();
                Destroy(gameObject);
            }
        }
    }
}
