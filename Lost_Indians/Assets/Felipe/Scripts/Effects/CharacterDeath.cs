using UnityEngine;
using System.Collections;

public class CharacterDeath : MonoBehaviour
{
    public float bounceForce = 300f;
    public float deathDuration = 0.5f;
    public GameObject particlePrefab; 

    public void Die()
    {
        StartCoroutine(DeathAnimation());
    }

    private IEnumerator DeathAnimation()
    {
        // Squash & Stretch
        transform.localScale = new Vector3(1.2f, 0.8f, 1f);
        yield return new WaitForSeconds(0.1f);

        transform.localScale = new Vector3(0.8f, 1.2f, 1f);
        yield return new WaitForSeconds(0.1f);

        // Rigidbody2D para o efeito de voo
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        rb.AddForce(Vector2.up * bounceForce);
        rb.AddTorque(500f);

        // Cria partículas
        if (particlePrefab != null)
        {
            Instantiate(particlePrefab, transform.position, Quaternion.identity);
        }

        // Espera e destrói o personagem
        yield return new WaitForSeconds(deathDuration);
        Destroy(gameObject);
    }
}
