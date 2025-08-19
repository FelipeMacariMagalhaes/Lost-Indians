using UnityEngine;

public class Interação_Objetros : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Game_Controller gameController;
    public bool isFounded = false;

    public string Objeto_Name_Dissapear = "Objeto";
    private GameObject objectToDissapear;

    private void Start()
    {
        gameController = FindObjectOfType<Game_Controller>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        objectToDissapear = GameObject.Find(Objeto_Name_Dissapear);

        if (objectToDissapear != null)
            objectToDissapear.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isFounded && other.CompareTag("Player"))
        {
            isFounded = true; 
            spriteRenderer.color = Color.green;
            Debug.Log("Objeto encontrado");

            if (objectToDissapear != null)
            {
                objectToDissapear.SetActive(false);
                Debug.Log("Desaparecimento");
            }

            if (gameController != null)
            {
                gameController.FoundObject();
                Debug.Log("Contabilização no gamecontroller");
            }
        }
    }
}