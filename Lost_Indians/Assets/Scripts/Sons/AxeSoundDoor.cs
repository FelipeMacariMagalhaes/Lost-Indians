using UnityEngine;

public class AxeSoundDoor : MonoBehaviour
{
    public AudioClip AxeClip;
    private AudioSource audioAxe;

    public AudioClip WoodbreakClip;
    private AudioSource AudioWoodbreak;

    void Start()
    {
        audioAxe = gameObject.AddComponent<AudioSource>();
        AudioWoodbreak = gameObject.AddComponent<AudioSource>();

        audioAxe.clip = AxeClip;
        audioAxe.loop = true;
        audioAxe.Play();

        AudioWoodbreak.clip = WoodbreakClip;
        AudioWoodbreak.loop = true;
        AudioWoodbreak.Play();
    }
}
