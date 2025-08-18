using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Game_Controller : MonoBehaviour
{
    public int foundObjects;
    public int objectsAmount = 8;
    public TMP_Text foundObjectsTxt;
    public UnityEvent OnVictory;

    private void Start()
    {
        UpdateFoundText();
    }

    public void FoundObject()
    {
        foundObjects++;
        UpdateFoundText();

        if (foundObjects >= objectsAmount)
        {
            OnVictory.Invoke();
        }
    }
    private void UpdateFoundText()
    {
        foundObjectsTxt.text = foundObjects + "/" + objectsAmount;
    }
}

