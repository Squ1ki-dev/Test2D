using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private Transform _currentPoint;
    [SerializeField] private Transform pointA, pointB;
    
    [SerializeField] private float _moveSpeed = 3f;
    private Rigidbody2D rb2d;
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _currentPoint = pointB.transform;
    }

    private void Update()
    {
        Vector2 point = _currentPoint.position - transform.position;

        //float moveInput = isFacingRight ? 1f : -1f;
        rb2d.velocity = new Vector2((_currentPoint == pointB) ? _moveSpeed : -_moveSpeed, rb2d.velocity.y);

        if (Vector2.SqrMagnitude(transform.position - _currentPoint.position) < 0.5f)
            _currentPoint = (_currentPoint == pointB) ? pointA : pointB;
    }
}