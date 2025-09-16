using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player != null)
            transform.position = player.position;
    }
}
