using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Portal : MonoBehaviour
{
    public Transform exit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.attachedRigidbody.position = exit.position;
    }
}
