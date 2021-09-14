using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Portal : MonoBehaviour
{
    public Transform exit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = exit.position;
        position.z = other.transform.position.z;  //Save Z coordinate
        other.transform.position = position;
    }
}
