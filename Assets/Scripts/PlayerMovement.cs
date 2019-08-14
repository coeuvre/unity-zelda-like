using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public float speed;

    private Vector3 _movement;
    
    void Update()
    {
        _movement = Vector3.zero;
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement = _movement.normalized;
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(transform.position + speed * Time.fixedDeltaTime * _movement);
    }
}
