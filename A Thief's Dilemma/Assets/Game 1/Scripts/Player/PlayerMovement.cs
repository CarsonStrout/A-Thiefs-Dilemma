using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float groundDrag;

    [SerializeField] private Transform orientation;

    [SerializeField] private bool dev; // allows dev sprint button
    private float devSprint = 0;
    [SerializeField] private float devSprintSpeed;

    [HideInInspector] public float horizontal;
    [HideInInspector] public float vertical;

    Vector3 moveDir;

    public Rigidbody RB { get; private set; }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.drag = groundDrag;
    }

    private void Update()
    {
        MyInput();
        MaxSpeed();

        if (dev) // checks to allow dev sprinting or not
            if (Input.GetKeyDown(KeyCode.Period))
            {
                if (devSprint == 0)
                    devSprint = devSprintSpeed;
                else
                    devSprint = 0;
            }
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

        RB.AddForce(moveDir * (moveSpeed + devSprint) * 10f, ForceMode.Force);
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
