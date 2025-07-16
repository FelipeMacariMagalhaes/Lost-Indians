using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class Game_Controller : MonoBehaviour
{
    public int foundObjects;
    public int objectsAmount = 8;
    public TMP_Text foundObjectsTxt;
    public UnityEvent OnVictory;

    private void Update()
    {
        foundObjectsTxt.text = foundObjects + "/" + objectsAmount;
    }
    public void FoundObject()
    {
        foundObjects++;
        if (foundObjects >= objectsAmount)
        {
            OnVictory.Invoke();
        }
    }

}

