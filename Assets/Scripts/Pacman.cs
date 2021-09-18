using UnityEngine;

public class Pacman : MovingObject
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _direction = Vector2.right;
        _animator = GetComponent<Animator>();
    }

    protected override void HandleInput()
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

    protected override void SetDirection(Vector2 dir)
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

    public void EatPoint(Point point)
    {
        Destroy(point.gameObject);
    }
}
