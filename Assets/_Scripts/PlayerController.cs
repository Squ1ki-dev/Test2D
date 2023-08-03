using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D rb2d;
    private bool _doubleJump;

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _groundLayer);
    }

    private void Awake() => rb2d = GetComponent<Rigidbody2D>();

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * _moveSpeed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        if (IsGrounded() || _doubleJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, _jumpForce);
            _doubleJump = !_doubleJump;
        }
    }
}
