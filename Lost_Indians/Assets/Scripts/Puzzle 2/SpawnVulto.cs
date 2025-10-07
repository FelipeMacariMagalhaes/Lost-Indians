using UnityEngine;
using System.Collections;

public class SpawnVulto : MonoBehaviour
{
    [Header("Boing Settings")]
    public float bounceForce = 400f;         // força do primeiro boing
    public float bounceForceAfterHit = 200f; // força menor pro segundo pulo
    public float gravity = 1f;
    public float torque = 600f;

    [Header("Fade Settings")]
    public float fadeSpeed = 2f;             // velocidade do fade

    private SpriteRenderer sr;
    private bool alreadyDead = false;
    private Rigidbody2D rb;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !alreadyDead)
        {
            alreadyDead = true;
            StartCoroutine(DeathSequence());
        }
    }

    private IEnumerator DeathSequence()
    {
        // ✨ Cria partículas mágicas
        CreateMagicParticles();

        // 🔸 Faz o boing animado (squash & stretch)
        yield return StartCoroutine(BoingStretch(1.3f, 0.7f, 0.08f));
        yield return StartCoroutine(BoingStretch(0.7f, 1.3f, 0.08f));

        // 🔸 Adiciona física e aplica força + torque
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
        rb.AddForce(Vector2.up * bounceForce);
        rb.AddTorque(torque);

        // Espera ele subir e cair um pouco
        yield return new WaitForSeconds(0.5f);

        // 🔸 Segundo boing
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * bounceForceAfterHit);
        yield return StartCoroutine(BoingStretch(1.2f, 0.8f, 0.1f));

        // Espera cair totalmente
        yield return new WaitForSeconds(0.8f);

        // 🔸 Inicia o fade out
        yield return StartCoroutine(FadeOutAndDestroy());
    }

    private IEnumerator BoingStretch(float xScale, float yScale, float time)
    {
        transform.localScale = new Vector3(xScale, yScale, 1f);
        yield return new WaitForSeconds(time);
        transform.localScale = Vector3.one;
    }

    private IEnumerator FadeOutAndDestroy()
    {
        if (sr == null)
            yield break;

        float alpha = sr.color.a;

        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;

            Color c = sr.color;
            c.a = Mathf.Clamp01(alpha);
            sr.color = c;

            yield return null;
        }

        // Espera um pouco pra dar tempo de ver o fade final
        yield return new WaitForSeconds(0.1f);

        // Destroi o inimigo no final
        Destroy(gameObject);
    }

    private void CreateMagicParticles()
    {
        GameObject particleObj = new GameObject("MagicParticles");
        particleObj.transform.position = transform.position;

        ParticleSystem ps = particleObj.AddComponent<ParticleSystem>();
        ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        var main = ps.main;
        main.loop = false;
        main.duration = 1f;
        main.startLifetime = new ParticleSystem.MinMaxCurve(0.6f, 1.2f);
        main.startSpeed = new ParticleSystem.MinMaxCurve(0.8f, 1.5f);
        main.startSize = new ParticleSystem.MinMaxCurve(0.1f, 0.2f);
        main.simulationSpace = ParticleSystemSimulationSpace.World;
        main.playOnAwake = false;

        var emission = ps.emission;
        emission.rateOverTime = 0;
        emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(0f, 120, 180) });

        var shape = ps.shape;
        shape.shapeType = ParticleSystemShapeType.Sphere;
        shape.radius = 0.15f;

        var colorOverLifetime = ps.colorOverLifetime;
        colorOverLifetime.enabled = true;
        Gradient grad = new Gradient();
        grad.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(new Color(0.8f, 0.5f, 1f), 0f),
                new GradientColorKey(new Color(0.68f, 0.9f, 1f), 1f)
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1f, 0f),
                new GradientAlphaKey(0f, 1f)
            }
        );
        colorOverLifetime.color = grad;

        var sizeOverLifetime = ps.sizeOverLifetime;
        sizeOverLifetime.enabled = true;
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0f, 0.2f);
        curve.AddKey(0.5f, 0.3f);
        curve.AddKey(1f, 0f);
        sizeOverLifetime.size = new ParticleSystem.MinMaxCurve(1f, curve);

        var noise = ps.noise;
        noise.enabled = true;
        noise.strength = 0.4f;

        ps.Play();
        Destroy(particleObj, main.duration + main.startLifetime.constantMax);
    }
}
