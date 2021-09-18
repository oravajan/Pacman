using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Pacman _pacman;

    private void Awake()
    {
        _pacman = FindObjectOfType<Pacman>();
        DontDestroyOnLoad(gameObject);
    }
}
