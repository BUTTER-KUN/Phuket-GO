using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed = 5f;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (movementJoystick != null) // Check if joystick is available
        {
            movement.x = movementJoystick.joystickVec.x;
            movement.y = movementJoystick.joystickVec.y;

            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else // Use keyboard input if joystick is not available
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        if (movementJoystick != null && movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movement.x * playerSpeed, movement.y * playerSpeed);
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}