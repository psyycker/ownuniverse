using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private Vector2 movement;

    [SerializeField]
    private float speed = 200f;

    [SerializeField] private float jumpForce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector2(
            movement.x * speed * Time.fixedDeltaTime,
            _rigidbody.velocity.y
            );
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void OnJump()
    {
        _rigidbody.velocity = new Vector2(
            _rigidbody.velocity.x,
            jumpForce
        );
    }
}
