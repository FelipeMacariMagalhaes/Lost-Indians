using UnityEngine;
using UnityEngine.Events;

public class Button_accept : MonoBehaviour
{
    public NPCDialogueTrigger nPC;
    public UnityEvent Quest1;
    public UnityEvent Quest2;
    public UnityEvent Quest3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Click()
    {
        if (nPC.questStage == 0)
        {
            Quest1.Invoke();
        }

        else if (nPC.questStage == 1) 
        {
            Quest1.Invoke();
        }

        else if (nPC.questStage == 2)
        {
            Quest2.Invoke();
        }

        else if(nPC.questStage == 3)
        {
            Quest3.Invoke();
        }
    }
}
