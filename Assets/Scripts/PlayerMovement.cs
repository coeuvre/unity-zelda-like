using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public float speed;
    public Animator animator;

    private Vector3 _movement;

    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Velocity = Animator.StringToHash("Velocity");

    void Update()
    {
        _movement = Vector3.zero;
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement = _movement.normalized;
        var velocity = _movement.sqrMagnitude;
        if (velocity > 0)
        {
            animator.SetFloat(Horizontal, _movement.x);
            animator.SetFloat(Vertical, _movement.y);
        }
        animator.SetFloat(Velocity, velocity);
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(transform.position + speed * Time.fixedDeltaTime * _movement);
    }
}