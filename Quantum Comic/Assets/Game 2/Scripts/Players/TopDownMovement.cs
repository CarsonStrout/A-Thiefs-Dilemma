using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public Rigidbody2D RB { get; private set; }

    [Header("Movement")]
    public float moveSpeed = 10f;

    Vector2 movement;


    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // movement input
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        // simple side movement
        RB.MovePosition(RB.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
