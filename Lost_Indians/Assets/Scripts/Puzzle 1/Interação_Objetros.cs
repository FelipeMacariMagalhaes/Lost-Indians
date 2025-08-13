using UnityEngine;

public class Interação_Objetros : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Game_Controller gameController;
    bool isFounded;
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


    private void OnMouseDown()
    {
        if (!isFounded)
        {
            spriteRenderer.color = Color.green;

            gameController.FoundObject();

            if (objectToDissapear != null)
                objectToDissapear.SetActive(false);


            isFounded = true;
        }
    }   
}
