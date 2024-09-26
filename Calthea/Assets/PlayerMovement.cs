using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Movement")]
    public float moveSpeed = 5f;
    float horizontalMovement;

    [Header("Jumping")]
    public float jumpPower = 10f;
    public int maxJumps = 2;
    int jumpsRemaining;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    [Header("Gravity")]
    public float baseGravity = 2f;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;

    void Start()
    {
        jumpsRemaining = maxJumps; // Initialize jumps remaining
    }

    void Update()
    {
        // Update horizontal movement
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
        ApplyGravity();
        GroundCheck();
    }

    private void ApplyGravity()
    {
        // Apply custom gravity scaling
        if (rb.velocity.y < 0) // Only adjust when falling
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            if (rb.velocity.y < -maxFallSpeed) // Limit the fall speed
            {
                rb.velocity = new Vector2(rb.velocity.x, -maxFallSpeed);
            }
        }
        else
        {
            rb.gravityScale = baseGravity; // Normal gravity when jumping or not falling
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0 && context.performed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpsRemaining--;
        }
    }

    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemaining = maxJumps; // Reset jumps when grounded
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
