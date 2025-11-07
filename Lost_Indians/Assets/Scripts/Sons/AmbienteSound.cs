using UnityEngine;

public class AmbienteSound : MonoBehaviour
{
    public AudioClip ambienteSound;

    private AudioSource audioAmbiente;

    void Start()
    {
        audioAmbiente = gameObject.AddComponent<AudioSource>();

        audioAmbiente.clip = ambienteSound;
        audioAmbiente.loop = true;        
        audioAmbiente.Play();
    }

}
