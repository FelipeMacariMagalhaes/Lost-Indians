using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI messageText; 
    private float TempoDeTexto;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (messageText.enabled && Time.time >= TempoDeTexto)
        {
            messageText.enabled = false;
        }
    }

    public void ShowMessage(string message, float duration)
    {
        messageText.text = message;
        messageText.enabled = true;
        TempoDeTexto = Time.time + duration;
    }
}

