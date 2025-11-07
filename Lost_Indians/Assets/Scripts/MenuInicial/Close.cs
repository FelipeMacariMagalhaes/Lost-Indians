using UnityEngine;
using UnityEngine.Events;
public class Close : MonoBehaviour
{
    public UnityEvent close;
    public void closeCredits()
    {
        close.Invoke();
    }
}
