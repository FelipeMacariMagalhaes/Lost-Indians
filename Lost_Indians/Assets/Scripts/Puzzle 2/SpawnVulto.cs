using UnityEngine;
using System.Collections;
using TMPro;

public class SpawnVulto : MonoBehaviour
{
   [Header("Boing Settings")]
    public float bounceForce = 400f;         
    public float bounceForceAfterHit = 200f; 
    public float gravity = 1f;
    public float torque = 600f;

    [Header("Fade Settings")]
    public float fadeSpeed = 2f;

    [Header("Texto Sustos")]
    public GameObject textoSusto; // Texto que aparece após desaparecer
    public float textoDuracao = 2f; // tempo que o texto fica visível
    public float textoFadeSpeed = 1f; // velocidade do fade do texto

    private SpriteRenderer sr;
    private bool alreadyCollided = false;
    private Rigidbody2D rb;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (textoSusto != null)
            textoSusto.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alreadyCollided)
        {
            alreadyCollided = true;
            StartCoroutine(CollisionEffect());
            
        }
    }

    private IEnumerator CollisionEffect()
    {
        // Criar partículas mágicas
        CreateMagicParticles();

        // Primeiro boing com easing
        yield return StartCoroutine(BoingStretchEase(1.3f, 0.7f, 0.08f));
        yield return StartCoroutine(BoingStretchEase(0.7f, 1.3f, 0.08f));

        // Física para efeito visual
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
        rb.AddForce(Vector2.up * bounceForce);
        rb.AddTorque(torque);

        yield return new WaitForSeconds(0.5f);

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * bounceForceAfterHit);

        // Segundo boing
        yield return StartCoroutine(BoingStretchEase(1.2f, 0.8f, 0.1f));

        yield return new WaitForSeconds(0.8f);

        // Fade do vulto/miragem
        yield return StartCoroutine(FadeOutAndDestroy());

        // Mostrar texto
        if (textoSusto != null)
        {
            textoSusto.SetActive(true);
            yield return StartCoroutine(FadeTextoEDepoisSumir(textoSusto, textoDuracao, textoFadeSpeed));
        }
    }

    private IEnumerator BoingStretchEase(float targetX, float targetY, float duration)
    {
        Vector3 startScale = transform.localScale;
        Vector3 targetScale = new Vector3(targetX, targetY, 1f);

        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            t = t * t * (3f - 2f * t); // Ease In-Out

            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        // Voltar para escala normal
        time = 0f;
        startScale = transform.localScale;
        targetScale = Vector3.one;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            t = t * t * (3f - 2f * t);

            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }
    }

    private IEnumerator FadeOutAndDestroy()
    {
        if (sr == null) yield break;

        float alpha = sr.color.a;

        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            Color c = sr.color;
            c.a = Mathf.Clamp01(alpha);
            sr.color = c;
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false); // ocultar vulto
    }

    private IEnumerator FadeTextoEDepoisSumir(GameObject texto, float duracao, float fadeSpeed)
    {
        TextMeshProUGUI tmp = texto.GetComponent<TextMeshProUGUI>();
        if (tmp == null) yield break;

        Color cor = tmp.color;
        cor.a = 1f;
        tmp.color = cor;

        yield return new WaitForSeconds(duracao);

        while (cor.a > 0f)
        {
            cor.a -= Time.deltaTime * fadeSpeed;
            tmp.color = cor;
            yield return null;
        }

        texto.SetActive(false);
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