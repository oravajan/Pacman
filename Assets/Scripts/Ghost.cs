using UnityEngine;

public class Ghost : MovingObject
{
    public Vector2 startPosition;
    public Vector2 startDirection;

    protected Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _direction = startDirection;
        _animator = GetComponent<Animator>();
    }
}
