using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Game_Controller : MonoBehaviour
{
    public int foundObjects;
    public int objectsAmount = 5;
    public TMP_Text foundObjectsTxt;
    public UnityEvent OnVictory;
    public UnityEvent Desactive;
    public string Quest;
    float time = 1f;
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
           
            foundObjects = 0;
            UpdateFoundText();
            OnVictory.Invoke();
            time -= Time.deltaTime;
            if(time <= 0)
            {
                Desactive.Invoke();
            }
        }
    }
    private void UpdateFoundText()
    {
        foundObjectsTxt.text = "Objetos coletados " + foundObjects + "/" + objectsAmount;
    }    
}

