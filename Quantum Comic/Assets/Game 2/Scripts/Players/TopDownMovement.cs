using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    [SerializeField] private Vector2[] goalPos;
    [SerializeField] private float speed;
    private int currentPos;
    private int movePos;
    private bool isMoving;

    private void Start()
    {
        isMoving = false;
        currentPos = 1;
    }

    private void Update()
    {
        if (isMoving)
        {
            StartCoroutine(Move(movePos));
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentPos == 1)
                movePos = 0;
            else if (currentPos == 2)
                movePos = 1;
            else
                return;
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentPos == 1)
                movePos = 2;
            else if (currentPos == 0)
                movePos = 1;
            else
                return;
            isMoving = true;
        }
    }

    IEnumerator Move(int targetPos)
    {
        transform.position = Vector2.Lerp(transform.position, goalPos[targetPos], speed * Time.deltaTime);

        currentPos = movePos;

        yield return null;
    }
}
