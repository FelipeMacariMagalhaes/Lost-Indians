using UnityEngine;

public class Interação_Objetros : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Game_Controller gameController;
    bool isFounded = false;

    public string Objeto_Name_Dissapear = "Objeto";
    private GameObject objectToDissapear;


    void Start()
    {
        gameController = FindObjectOfType(typeof(Game_Controller)) as Game_Controller;

        spriteRenderer = GetComponent<SpriteRenderer>();

        objectToDissapear = GameObject.Find(Objeto_Name_Dissapear);

        if (objectToDissapear != null)
            objectToDissapear.SetActive(true);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isFounded && other.CompareTag("Player"))
        {
            spriteRenderer.color = Color.green;

            if (gameController != null)
                gameController.FoundObject();

            if (objectToDissapear != null)
                objectToDissapear.SetActive(false);

            isFounded = true;
        }
    }
}
