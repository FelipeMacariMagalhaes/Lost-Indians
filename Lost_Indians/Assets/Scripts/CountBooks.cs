using UnityEngine;

public class  CountBooks : MonoBehaviour
{
    [Header("Configuração do Livro")]
    public string CollectMessage = "Livro coletado!";
    public float Duration = 2f;
    private bool collected = false;

    protected virtual void OnCollect()
    {
        
        if (collected) return;
        collected = true;

        UIManager.Instance.ShowMessage(CollectMessage, Duration);
        GameManager.Instance.LivroColetado();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollect();
        }
    }
}

