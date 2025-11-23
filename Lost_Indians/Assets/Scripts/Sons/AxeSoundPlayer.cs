using UnityEngine;

public class AxeSoundPlayer : MonoBehaviour
{
    public AudioClip AxeClip;
    private AudioSource audioAxe;

    public AudioClip CorpseClip;
    private AudioSource AudioCorpse;

    void Start()
    {
        audioAxe = gameObject.AddComponent<AudioSource>();
        AudioCorpse = gameObject.AddComponent<AudioSource>();

        audioAxe.clip = AxeClip;
        audioAxe.loop = true;
        audioAxe.Play();

        AudioCorpse.clip = CorpseClip;
        AudioCorpse.loop = true;
        AudioCorpse.Play();
    }
}
