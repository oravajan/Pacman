using UnityEngine;

public class Point : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            other.gameObject.GetComponent<Pacman>().EatPoint(this);
        }
    }
}
