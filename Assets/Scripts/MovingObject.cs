using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MovingObject : MonoBehaviour
{
    public LayerMask walls;
    
    [SerializeField] protected float _speed;
    
    protected Rigidbody2D _rigidbody;

    protected Vector2 _direction = Vector2.right;
    protected Vector2 _nextDirection = Vector2.zero;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        HandleInput();
        SetDirection(_nextDirection);
    }

    protected virtual void FixedUpdate()
    {
        Vector2 translation = _direction * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + translation);
    }

    protected virtual void HandleInput()
    {
    }

    protected virtual void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }
    
    protected bool CheckDirection(Vector2 dir)
    {
        //Checks if in given direction is not wall
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.8f, 0.0f, dir, 1.5f, walls);
        return hit.collider == null;
    }
}
