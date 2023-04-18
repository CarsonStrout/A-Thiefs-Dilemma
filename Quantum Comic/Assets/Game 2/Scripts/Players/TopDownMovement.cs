using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private GameManager2 gameManager;

    [SerializeField] private Vector2 startPos;
    [SerializeField] private float beginningSpeed;
    [SerializeField] private Vector2 finalPos;
    [SerializeField] private float finalSpeed;

    [SerializeField] private Vector2[] goalPos;
    [SerializeField] private float speed;
    private int currentPos;
    private int movePos;
    private bool isBeginning;
    private bool isMoving;

    private void Start()
    {
        isBeginning = true;
        isMoving = false;
        currentPos = 1;
    }

    private void Update()
    {
        if (gameManager.freeEnd)
        {
            StartCoroutine(EndMove(finalPos));
            return;
        }

        if (isBeginning)
        {
            StartCoroutine(StartMove(startPos));
            return;
        }

        if (isMoving)
            StartCoroutine(Move(movePos));

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

    IEnumerator StartMove(Vector2 targetPos)
    {
        transform.position = Vector2.Lerp(transform.position, startPos, beginningSpeed * Time.deltaTime);

        if (transform.position.y > startPos.y - 0.5)
            isBeginning = false;

        yield return null;
    }

    IEnumerator EndMove(Vector2 targetPos)
    {
        transform.position = Vector2.Lerp(transform.position, finalPos, finalSpeed * Time.deltaTime);

        yield return null;
    }
}
