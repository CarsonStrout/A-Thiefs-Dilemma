using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollMovement : MonoBehaviour
{
    public Rigidbody2D RB { get; private set; }

    [Header("Stats")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float maxSpeed = 25f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float coyoteTime = 0.15f;
    [SerializeField] private float jumpBufferTime = 0.1f;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    [Space(5)]
    [Header("Checks")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Space(5)]
    [SerializeField] private RewindTime rewindTime;

    private bool isFacingRight = true;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(dirX, dirY);

        // returns to not override the rewinding of positions
        if (rewindTime.isRewinding)
            return;

        // limits the max velocity of the player
        if (RB.velocity.magnitude > maxSpeed)
            RB.velocity = Vector2.ClampMagnitude(RB.velocity, maxSpeed);

        // allows the player to jump slightly after they leave an edge to make the game feel less restrictive
        if (IsGrounded())
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;

        Walk(dir);

        // uses a jump buffer to let the player "queue" up a jump before they hit the ground within a certain amount of time
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f)
        {
            if (coyoteTimeCounter > 0f)
            {
                Jump(Vector2.up);

                jumpBufferCounter = 0f;
            }
        }

        // variable jump heights by decreasing the y velocity by half if space is let go
        if (Input.GetButtonUp("Jump") && RB.velocity.y > 0f)
        {
            RB.velocity = new Vector2(RB.velocity.x, RB.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void Jump(Vector2 dir)
    {
        RB.velocity = new Vector2(RB.velocity.x, 0);
        RB.velocity += dir * jumpForce;
    }

    private void Walk(Vector2 dir)
    {
        RB.velocity = new Vector2(dir.x * speed, RB.velocity.y);
    }
}
