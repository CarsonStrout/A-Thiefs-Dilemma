using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float airMultiplier;

    [Space(5)]
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    private bool isGrounded;

    public Transform orientation;

    [HideInInspector] public float horizontal;
    [HideInInspector] public float vertical;

    Vector3 moveDir;

    public Rigidbody RB { get; private set; }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

        MyInput();
        MaxSpeed();

        // Drag
        if (isGrounded)
            RB.drag = groundDrag;
        else
            RB.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDir = orientation.forward * vertical + orientation.right * horizontal;

        // slightly different movespeed when in the air - not applicable at the moment
        if (isGrounded)
            RB.AddForce(moveDir * moveSpeed * 10f, ForceMode.Force);
        else
            RB.AddForce(moveDir * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void MaxSpeed()
    {
        Vector3 flatVel = new Vector3(RB.velocity.x, 0f, RB.velocity.z);

        // Limit velocity
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            RB.velocity = new Vector3(limitedVel.x, RB.velocity.y, limitedVel.z);
        }
    }
}
