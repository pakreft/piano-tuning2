using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Outline))]
public abstract class ClickableBase : MonoBehaviour
{
    public AudioClip sound = null;
    public UnityEvent onClick = null;

    private void Start()
    {
        enabled = true;
    }
}