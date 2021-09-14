using UnityEngine;

public class Pacman : MonoBehaviour
{
    public LayerMask walls;
    
    [SerializeField] private float _speed = 8f;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _direction = Vector2.right;
    private Vector2 _nextDirection = Vector2.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
        SetDirection(_nextDirection);
    }

    private void FixedUpdate()
    {
        Vector2 translation = _direction * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + translation);
    }

    private void SetDirection(Vector2 dir)
    {
        if (dir == Vector2.zero)  //Not valid direction, player did not enter his "next move"
            return;
        
        if (CheckDirection(dir))
        {
            _direction = dir;
            _nextDirection = Vector2.zero;  //Resets next direction
            
            //Animation
            _animator.SetFloat("DirX", dir.x);
            _animator.SetFloat("DirY", dir.y);
        }
    }
    
    private bool CheckDirection(Vector2 dir)
    {
        //Checks if in given direction is not wall
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.8f, 0.0f, dir, 1.5f, walls);
        return hit.collider == null;
    }
    
    private void HandleInput()
    {
        //Sets next position from player input
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            _nextDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            _nextDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            _nextDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            _nextDirection = Vector2.right;
        }
    }
}
